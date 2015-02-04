using System;
using System.Threading;
using System.Threading.Tasks;
using BotBits.Annotations;
using BotBits.Nito;
using BotBits.SendMessages;
using PlayerIOClient;

namespace BotBits
{
    public class MessageQueue<T> : IMessageQueue where T : SendMessage<T>
    {
        public event EventHandler<SendQueueEventArgs<T>> Send;

        protected virtual void OnSend(SendQueueEventArgs<T> e)
        {
            var handler = this.Send;
            if (handler != null) handler(this, e);
        }

        private readonly ManualResetEvent _finishEvent = new ManualResetEvent(true);
        private readonly Deque<T> _queue = new Deque<T>();
        private int _lastTicks;

        public int Count
        {
            get
            {
                lock (this._queue)
                {
                    return this._queue.Count;
                }
            }
        }
        
        void IMessageQueue.SendTicks(int ticks, Connection connection)
        {
            var c = ticks - 4;

            for (this._lastTicks = Math.Max(c, this._lastTicks); this._lastTicks < ticks; this._lastTicks++)
            {
                var msg = this.Dequeue();
                if (msg == null) return;

                var e = new SendQueueEventArgs<T>(msg);
                this.OnSend(e);
                if (!e.Cancelled)
                {
                    e.Message.Send(connection);
                }
                else
                {
                    this._lastTicks--;
                }
            }
        }

        [CanBeNull]
        private T Dequeue()
        {
            lock (this._queue)
            {
                if (this._queue.Count == 0)
                    return null;

                var first = this._queue.RemoveFromFront();

                if (this._queue.Count == 0)
                    this._finishEvent.Set();

                return first;
            }
        }

        internal void Enqueue(T sendMessage)
        {
            lock (this._queue)
            {
                if (sendMessage.SkipsQueue)
                    this._queue.AddToFront(sendMessage);
                else
                    this._queue.AddToBack(sendMessage);

                this._finishEvent.Reset();
            }
        }

        public void ClearQueue()
        {
            lock (this._queue)
            {
                this._queue.Clear();
                this._finishEvent.Set();
            }
        }

        public void FinishQueue()
        {
            this._finishEvent.WaitOne();
        }

        public Task FinishQueueAsync()
        {
           return this._finishEvent.AsTask();
        }
    }
}