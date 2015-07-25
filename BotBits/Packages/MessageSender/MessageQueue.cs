using System;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using BotBits.Nito;
using BotBits.SendMessages;

namespace BotBits
{
    public class MessageQueue<T> : IMessageQueue where T : SendMessage<T>
    {
        public event EventHandler<SendEventArgs<T>> Send;

        protected virtual void OnSend(SendEventArgs<T> e)
        {
            var handler = this.Send;
            if (handler != null) handler(this, e);
        }

        public event EventHandler<SendingEventArgs<T>> Sending;

        protected virtual void OnSending(SendingEventArgs<T> e)
        {
            var handler = this.Sending;
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
        
        void IMessageQueue.SendTicks(int ticks, IConnection connection)
        {
            var c = ticks - 4; // Max number of messages sent at once

            for (this._lastTicks = Math.Max(c, this._lastTicks); this._lastTicks < ticks; this._lastTicks++)
            {
                var msg = this.Dequeue();
                if (msg == null) return;
                if (!this.SendMessage(msg, connection))
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

        internal bool SendMessage(T msg, IConnection connection)
        {
            var e = new SendingEventArgs<T>(msg);
            this.OnSending(e);
            if (!e.Cancelled)
            {
                var e2 = new SendEventArgs<T>(msg);
                this.OnSend(e2);

                e.Message.Send(connection);

                return true;
            }
            return false;
        }

        public void ClearQueue()
        {
            lock (this._queue)
            {
                this._queue.Clear();
                this._finishEvent.Set();
            }
        }

        public Task FinishQueueAsync()
        {
           return this._finishEvent.AsTask();
        }
    }
}