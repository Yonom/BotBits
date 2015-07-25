using System;
using System.Threading;
using System.Threading.Tasks;
using BotBits.Events;
using BotBits.SendMessages;
using PlayerIOClient;

namespace BotBits
{
    public sealed class ConnectionManager : Package<ConnectionManager>, IDisposable, 
        IPlayerIOGame<LoginClient>, IConnectionManager<LoginClient>
    {
        private IConnection _connection;
        private PlayerIOConnectionAdapter _adapter;
        public Scheduler CurrentScheduler { get; private set; }
        public IConnection Connection
        {
            get { return this._connection; }
        }

        [Obsolete("Invalid to use \"new\" on this class. Use the static .Of(botBits) method instead.", true)]
        public ConnectionManager()
        {
            this.CurrentScheduler = new Scheduler();
        }

        /// <summary>
        /// Gets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public ShopData ShopData { get; private set; }

        /// <summary>
        /// Gets the player object.
        /// </summary>
        /// <value>
        /// The player object.
        /// </value>
        public PlayerObject PlayerObject { get; private set; }

        void IDisposable.Dispose()
        {
            if (this._adapter != null)
                this._adapter.Dispose();

            this.CurrentScheduler.Dispose();
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

            this.PlayerObject = args.PlayerObject;
            this.ShopData = args.ShopData;

            new ConnectEvent()
                .RaiseIn(this.BotBits);

            new InitSendMessage()
                .SendIn(this.BotBits);

            this.Connection.OnMessage += this.Connection_OnMessage;
            this.Connection.OnDisconnect += this.Connection_OnDisconnect;
            if (!this.Connection.Connected)
            {
                this.HandleDisconnect(String.Empty);
            }
        }

        private void Connection_OnMessage(object sender, Message e)
        {
            this.CurrentScheduler.Schedule(() =>
                this.HandleMessage(e));
        }

        private void Connection_OnDisconnect(object sender, string message)
        {
            this.CurrentScheduler.Schedule(() => 
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