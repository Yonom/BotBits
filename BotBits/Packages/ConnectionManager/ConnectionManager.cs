using System;
using System.Threading;
using BotBits.Events;
using PlayerIOClient;

namespace BotBits
{
    public sealed class ConnectionManager : Package<ConnectionManager>, IDisposable, 
        IPlayerIOGame<LoginClient>, IConnectionManager<LoginClient>
    {
        private PlayerIOConnectionAdapter _adapter;
        private IConnection _connection;
        public IConnection Connection
        {
            get { return this._connection; }
        }

        [Obsolete("Invalid to use \"new\" on this class. Use the static .Of(BotBits) method instead.", true)]
        public ConnectionManager()
        {
        }

        /// <summary>
        /// Gets the player data.
        /// </summary>
        /// <value>
        /// The player data.
        /// </value>
        public PlayerData PlayerData { get; private set; }

        public string RoomId { get; private set; }

        public string ConnectUserId { get; private set; }

        void IDisposable.Dispose()
        {
            if (this._adapter != null)
                this._adapter.Dispose();
        }

        void IConnectionManager.AttachConnection(Connection connection, ConnectionArgs args)
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

        public LoginClient WithClient(Client client)
        {
            return new LoginClient(this, client);
        }

        public PlayerIOGame WithGameId(string gameId)
        {
            return new PlayerIOGame(this, gameId);
        }

        public void SetConnection(IConnection connection, ConnectionArgs args)
        {
            if (connection == null)
                throw new ArgumentNullException("connection");

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
                this.HandleDisconnect(String.Empty);
            }
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

        public string GameId { get { return "everybody-edits-su9rn58o40itdbnw69plyw"; } }
        IConnectionManager<LoginClient> IPlayerIOGame<LoginClient>.ConnectionManager { get { return this; } }
    }
}