using System;
using System.Collections.Concurrent;
using BotBits.SendMessages;

namespace BotBits
{
    internal sealed class MessageSender : Package<MessageSender>, IDisposable
    {
        private SendTimer _myTimer;
        private readonly ConcurrentDictionary<Type, IMessageQueue> _queues =
            new ConcurrentDictionary<Type, IMessageQueue>();

        [Obsolete("Invalid to use \"new\" on this class. Use the static .Of(BotBits) method instead.", true)]
        public MessageSender()
        {
            this.InitializeFinish += this.MessageSender_InitializeFinish;
        }

        void MessageSender_InitializeFinish(object sender, EventArgs e)
        {
            this._myTimer = new SendTimer();
            this._myTimer.Elapsed += this.Send;
        }

        void IDisposable.Dispose()
        {
            this._myTimer.Dispose();
        }

        private void Send(int ticks)
        {
            var con = ConnectionManager.Of(this.BotBits).Connection;
            if (con == null) return;

            foreach (var e in this._queues.Values)
            {
                e.SendTicks(ticks, con);
            }
        }

        internal MessageQueue<T> GetQueue<T>() where T : SendMessage<T>
        {
            return (MessageQueue<T>)this._queues.GetOrAdd(typeof(T), t => new MessageQueue<T>());
        }
    }
}