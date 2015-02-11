using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using BotBits.Events;
using BotBits.Nito;
using BotBits.SendMessages;

namespace BotBits
{
    public sealed class BlockChecker : EventListenerPackage<BlockChecker>, IDisposable
    {
        private readonly Deque<CheckHandle> _sentBlocks = new Deque<CheckHandle>(100);
        private readonly Dictionary<Point3D, CheckHandle> _sentLocations = new Dictionary<Point3D, CheckHandle>(100);
        private readonly AutoResetEvent _timeoutResetEvent = new AutoResetEvent(true);
        private readonly ManualResetEvent _finishResetEvent = new ManualResetEvent(true);
        private readonly RegisteredWaitHandle _registration;
        private Blocks _world;
        private MessageQueue<PlaceSendMessage> _messageQueue;
            
        [Obsolete("Invalid to use \"new\" on this class. Use the static .Of(botBits) method instead.", true)]
        public BlockChecker()
        {
            this.InitializeFinish += this.BlockChecker_InitializeFinish;
            this._registration = this.RegisterSendTimeout();
        }

        private void BlockChecker_InitializeFinish(object sender, EventArgs e)
        {
            this._world = Package<Blocks>.Of(this.BotBits);
            this._messageQueue = PlaceSendMessage.Of(this.BotBits);
            this._messageQueue.Send += this.OnSendPlace;
        }
        
        private RegisteredWaitHandle RegisterSendTimeout()
        {
            return ThreadPool.RegisterWaitForSingleObject(this._timeoutResetEvent, (state, timedOut) =>
            {
                if (!timedOut) return;
                if (this._sentBlocks.Count == 0) return;
                if (this._messageQueue.Count != 0) return;

                lock (this._sentBlocks)
                {
                    this.RepairMissed();
                }
            }, null, 500, false);
        }

        void IDisposable.Dispose()
        {
            this._registration.Unregister(null);
            this._timeoutResetEvent.Dispose();
            this._finishResetEvent.Dispose();
        }

        public void FinishChecks()
        {
            this._finishResetEvent.WaitOne();
        }

        public Task FinishChecksAsync()
        {
            return this._finishResetEvent.AsTask();
        }

        private void UpdateFinish()
        {
            if (this._sentBlocks.Count == 0 &&
                this._messageQueue.Count == 0)
                this._finishResetEvent.Set();
        }

        [EventListener(EventPriority.High)]
        private void OnForeground(ForegroundPlaceEvent e)
        {
            this.Repair<ForegroundPlaceEvent, ForegroundBlock>(Layer.Foreground, e);
        }

        [EventListener(EventPriority.High)]
        private void OnBackground(BackgroundPlaceEvent e)
        {
            this.Repair<BackgroundPlaceEvent, BackgroundBlock>(Layer.Background, e);
        }

        private void Repair<T, TBlock>(Layer layer, T e)
            where T : PlaceEvent<T, TBlock> where TBlock : struct
        {
            // Make sure the block was uploaded by this bot
            var p = e.New.Placer;
            if (p != null && p != Package<Players>.Of(this.BotBits).OwnPlayer) return;

            lock (this._sentBlocks)
            {
                var point = new Point3D(layer, e.X, e.Y);

                // Make sure we have sent a block at this location
                CheckHandle testB;
                if (!this._sentLocations.TryGetValue(point, out testB)) return;

                // If we have sent mutliple blocks at this position, wait until we receive the last one 
                if (testB.OverwrittenSends != 0)
                {
                    testB.OverwrittenSends--;
                }
                else if (AreSame<T, TBlock>(testB.Message, e))
                {
                    // Reset the timeout
                    this._timeoutResetEvent.Set();

                    this.RepairMissed(point);
                }
            }
        }
        
        private void RepairMissed(Point3D? point = null)
        {
            while (this._sentBlocks.Count > 0)
            {
                var current = this._sentBlocks.RemoveFromFront();
                var currentPoint = current.Message.GetPoint3D();
                this._sentLocations.Remove(currentPoint);

                // If we arrived at the block we received, exit the checks
                if (currentPoint == point)
                    break;

                this.SendMissed(current);
            }

            this.UpdateFinish();
        }

        private void SendMissed(CheckHandle handle)
        {
            MessageServices.EnableSkipsQueue(() =>
            {
                handle.Message.SendIn(this.BotBits);
            });
        }

        private void OnSendPlace(object sender, SendQueueEventArgs<PlaceSendMessage> e)
        {
            var b = e.Message;
            var p = b.GetPoint3D();

            lock (this._sentBlocks)
            {
                if (this.ShouldSend(b, p))
                {
                    this._timeoutResetEvent.Set();
                    this._finishResetEvent.Reset();

                    var overwrritenSends = 0;
                    CheckHandle oldHandle;
                    if (this._sentLocations.TryGetValue(p, out oldHandle))
                    {
                        this._sentBlocks.Remove(oldHandle);
                        overwrritenSends = oldHandle.OverwrittenSends + 1;
                    }

                    var newHandle = new CheckHandle(b, overwrritenSends);
                    this._sentBlocks.AddToBack(newHandle);
                    this._sentLocations[p] = newHandle;
                }
                else
                {
                    e.Cancelled = true;

                    this.UpdateFinish();
                }
            }
        }

        private bool ShouldSend(PlaceSendMessage b, Point3D p)
        {
            if (b.SendCount > 10) return false;
            if (b.NoChecks) return true;
            if (!BlockUtils.IsPlaceable(b, this._world)) return false;

            CheckHandle handle;
            return !(this._sentLocations.TryGetValue(p, out handle) 
                ? BlockUtils.AreSame(b, handle.Message) 
                : BlockUtils.IsAlreadyPlaced(b, this._world));
        }

        private static bool AreSame<T, TBlock>(PlaceSendMessage sent, T received)
            where T : PlaceEvent<T, TBlock>
            where TBlock : struct
        {
            var bg = received as BackgroundPlaceEvent;
            if (bg != null)
                return BlockUtils.AreSame(sent, bg);
            var fg = received as ForegroundPlaceEvent;
            if (fg != null)
                return BlockUtils.AreSame(sent, fg);

            throw new NotSupportedException("Unknown PlaceEvent.");
        }
        
        private sealed class CheckHandle
        {
            public int OverwrittenSends { get; set; }
            public PlaceSendMessage Message { get; private set; }

            public CheckHandle(PlaceSendMessage message, int overwrittenSends)
            {
                this.Message = message;
                this.OverwrittenSends = overwrittenSends;
            }
        }
    }
}