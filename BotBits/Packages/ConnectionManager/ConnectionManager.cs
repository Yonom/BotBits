using System;
using System.Threading;
using BotBits.Events;
using PlayerIOClient;

namespace BotBits
{
    public sealed class ConnectionManager : Package<ConnectionManager>, IConnectionManager, IDisposable
    {
        private PlayerIOConnectionAdapter _adapter;
        private IConnection _connection;

        [Obsolete("Invalid to use \"new\" on this class. Use the static .Of(BotBits) method instead.", true)]
        public ConnectionManager()
        {
        }

        public IConnection Connection => this._connection;

        public PlayerData PlayerData { get; private set; }

        public string RoomId { get; private set; }

        public string ConnectUserId { get; private set; }

        public void AttachConnection(Connection connection, ConnectionArgs args)
        {
            var adapter = new PlayerIOConnectionAdapter(connection);
            try
            {
                this.SetConnection(adapter, args);
                this._adapter = adapter;
            }
            catch
            {
                adapter.Dispose();
                throw;
            }
        }

        public void SetConnection(IConnection connection, ConnectionArgs args)
        {
            if (connection == null) throw new ArgumentNullException(nameof(connection));

            if (Interlocked.CompareExchange(ref this._connection, connection, null) != null)
            {
                throw new InvalidOperationException("A connection has already been established.");
            }

            this.ConnectUserId = args.ConnectUserId;
            this.RoomId = args.RoomId;
            this.PlayerData = args.PlayerData;

            new ConnectEvent()
                .RaiseIn(this.BotBits);

            this.Connection.OnMessage += this.Connection_OnMessage;
            this.Connection.OnDisconnect += this.Connection_OnDisconnect;
            if (!this.Connection.Connected)
            {
                this.HandleDisconnect(string.Empty);
            }
        }

        void IDisposable.Dispose()
        {
            this._adapter?.Dispose();
        }

        private void Connection_OnMessage(object sender, Message e)
        {
            Scheduler.Of(this.BotBits).Schedule(() =>
                this.HandleMessage(e));
        }

        private void Connection_OnDisconnect(object sender, string message)
        {
            Scheduler.Of(this.BotBits).Schedule(() =>
                this.HandleDisconnect(message));
        }

        private void HandleMessage(Message message)
        {
            new PlayerIOMessageEvent(message)
                .RaiseIn(this.BotBits);
        }

        private void HandleDisconnect(string message)
        {
            new DisconnectEvent(message)
                .RaiseIn(this.BotBits);
        }
    }
}