using System;
using System.Collections.Concurrent;
using BotBits.SendMessages;

namespace BotBits
{
    internal sealed class MessageSender : Package<MessageSender>, IDisposable
    {
        private readonly ConcurrentDictionary<Type, IMessageQueue> _queues =
            new ConcurrentDictionary<Type, IMessageQueue>();

        private SendTimer _myTimer;

        [Obsolete("Invalid to use \"new\" on this class. Use the static .Of(BotBits) method instead.", true)]
        public MessageSender()
        {
            this.InitializeFinish += this.MessageSender_InitializeFinish;
        }

        void IDisposable.Dispose()
        {
            this._myTimer.Dispose();
        }

        private void MessageSender_InitializeFinish(object sender, EventArgs e)
        {
            this._myTimer = new SendTimer();
            this._myTimer.Elapsed += this.Send;
        }

        private void Send(int ticks)
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