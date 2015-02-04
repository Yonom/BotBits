using System;
using System.Collections.Concurrent;
using BotBits.SendMessages;

namespace BotBits
{
    internal sealed class MessageSender : Package<MessageSender>, IDisposable
    {
        // TODO: Disable when there are no messages waiting
        private readonly SendTimer _myTimer;
        private readonly ConcurrentDictionary<Type, IMessageQueue> _queues =
            new ConcurrentDictionary<Type, IMessageQueue>();

        private ConnectionManager _connectionManager;

        [Obsolete("Invalid to use \"new\" on this class. Use the static .Of(botBits) method instead.", true)]
        public MessageSender()
        {
            this._myTimer = new SendTimer();
            this._myTimer.Elapsed += this.Send;
            this.InitializeFinish += this.MessageSender_InitializeFinish;
        }

        private void MessageSender_InitializeFinish(object sender, EventArgs e)
        {
            this._connectionManager = ConnectionManager.Of(this.BotBits);
        }

        void IDisposable.Dispose()
        {
            this._myTimer.Dispose();
        }

        private void Send(int ticks)
        {
            if (this._connectionManager == null) return;
            if (this._connectionManager.Connection == null) return;

            foreach (var e in this._queues.Values)
            {
                e.SendTicks(ticks, this._connectionManager.Connection);
            }
        }

        internal MessageQueue<T> GetQueue<T>() where T : SendMessage<T>
        {
            return (MessageQueue<T>)this._queues.GetOrAdd(typeof(T), t => new MessageQueue<T>());
        }
    }
}