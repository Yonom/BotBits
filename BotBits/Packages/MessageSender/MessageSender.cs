using System;
using System.Collections.Concurrent;
using BotBits.Events;
using BotBits.SendMessages;

namespace BotBits
{
    public sealed class MessageSender : EventListenerPackage<MessageSender>, IDisposable
    {
        private readonly ConcurrentDictionary<Type, IMessageQueue> _queues =
            new ConcurrentDictionary<Type, IMessageQueue>();

        private SendTimer _myTimer;
        private double _sendTimerFrequency;

        [Obsolete("Invalid to use \"new\" on this class. Use the static .Of(BotBits) method instead.", true)]
        public MessageSender()
        {
            this.InitializeFinish += this.MessageSender_InitializeFinish;
        }

        void IDisposable.Dispose()
        {
            this._myTimer.Dispose();
        }
        
        [EventListener]
        private void On(InitEvent e)
        {
            if (this.SendTimerFrequency > 0) return;
            this.SendTimerFrequency = e.IsOwner ? 500 : 96.5;
        }

        public double SendTimerFrequency
        {
            get
            {
                if (this._sendTimerFrequency <= 0)
                    throw new InvalidOperationException("This value can only be accessed after it has been initialized."); 
                return this._sendTimerFrequency;
            }
            set
            {
                if (value <= 0)
                    throw new InvalidOperationException("Frequency is too small!");
                this._sendTimerFrequency = value;

                this._myTimer.UpdateFrequency(this._sendTimerFrequency);
            }
        }

        private void MessageSender_InitializeFinish(object sender, EventArgs e)
        {
            this._myTimer = new SendTimer();
            this._myTimer.Elapsed += this.Send;
        }

        private void Send(long ticks)
        {
            foreach (var e in this._queues.Values)
            {
                e.SendTicks(ticks, this.BotBits);
            }
        }

        internal MessageQueue<T> GetQueue<T>() where T : SendMessage<T>
        {
            return (MessageQueue<T>)this._queues.GetOrAdd(typeof(T), t => new MessageQueue<T>());
        }
    }
}