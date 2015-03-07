using System;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using BotBits.Events;
using BotBits.SendMessages;
using PlayerIOClient;

namespace BotBits
{
    public sealed class ConnectionManager : Package<ConnectionManager>, IDisposable
    {
        private const string GameId = "everybody-edits-su9rn58o40itdbnw69plyw";
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

        [Pure]
        public LoginClient GuestLogin()
        {
            return this.GuestLoginAsnyc().Result;
        }

        [Pure]
        public LoginClient EmailLogin(string email, string password)
        {
            return this.EmailLoginAsync(email, password).Result;
        }

        [Pure]
        public LoginClient FacebookLogin(string token)
        {
            return this.FacebookLoginAsync(token).Result;
        }

        [Pure]
        public LoginClient KongregateLogin(string userId, string token)
        {
            return this.KongregateLoginAsync(userId, token).Result;
        }

        [Pure]
        public LoginClient ArmorGamesLogin(string userId, string token)
        {
            return this.ArmorGamesLoginAsync(userId, token).Result;
        }

        [Pure]
        public Task<LoginClient> GuestLoginAsnyc()
        {
            return this.EmailLoginAsync("guest", "guest");
        }

        [Pure]
        public Task<LoginClient> EmailLoginAsync(string email, string password)
        {
            this.CurrentScheduler.InitScheduler();

            var tcs = new TaskCompletionSource<LoginClient>();
            PlayerIO.QuickConnect.SimpleConnect(GameId, email, password, null,
                cl => tcs.SetResult(this.WithClient(cl)),
                tcs.SetException);
            return tcs.Task;
        }

        [Pure]
        public Task<LoginClient> FacebookLoginAsync(string token)
        {
            this.CurrentScheduler.InitScheduler();

            var tcs = new TaskCompletionSource<LoginClient>();
            PlayerIO.QuickConnect.FacebookOAuthConnect(GameId, token, null, null,
                cl => tcs.SetResult(this.WithClient(cl)),
                tcs.SetException);
            return tcs.Task;
        }

        [Pure]
        public Task<LoginClient> KongregateLoginAsync(string userId, string token)
        {
            this.CurrentScheduler.InitScheduler();

            var tcs = new TaskCompletionSource<LoginClient>();
            PlayerIO.QuickConnect.KongregateConnect(GameId, userId, token, null,
                cl => tcs.SetResult(this.WithClient(cl)),
                tcs.SetException);
            return tcs.Task;
        }

        [Pure]
        public Task<LoginClient> ArmorGamesLoginAsync(string userId, string token)
        {
            this.CurrentScheduler.InitScheduler();

            return this.GuestLoginAsnyc().ContinueWith(t =>
            {
                var tcs = new TaskCompletionSource<LoginClient>();
                t.Result.Client.Multiplayer.JoinRoom(String.Empty, null, guestConn =>
                {
                    guestConn.OnMessage += (sender, message) =>
                    {
                        try
                        {
                            if (message.Type != "auth" || message.Count < 2)
                                throw new ArgumentException("Auth failed.");

                            tcs.TrySetResult(this.WithClient(PlayerIO.Connect(
                                GameId,
                                "secure",
                                message.GetString(0),
                                message.GetString(1),
                                "armorgames")));
                        }
                        catch (Exception ex)
                        {
                            tcs.TrySetException(ex);
                        }
                        finally
                        {
                            guestConn.Disconnect();
                        }
                    };
                    guestConn.OnDisconnect += (sender, message) =>
                        tcs.TrySetException(new ArgumentException("Auth failed."));
                    if (!guestConn.Connected)
                        tcs.TrySetException(new ArgumentException("Auth failed."));
                    guestConn.Send("auth", userId, token);
                }, tcs.SetException);
                return tcs.Task;
            }).Unwrap();
        }

        [Pure]
        public LoginClient WithClient([NotNull] Client client)
        {
            this.CurrentScheduler.InitScheduler();

            if (client == null)
                throw new ArgumentNullException("client");

            return new LoginClient(this, client);
        }

        public void SetConnection([NotNull] IConnection connection, ConnectionArgs args)
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

        internal void SetConnectionInternal([NotNull] Connection connection, ConnectionArgs args)
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
            new MessageEvent(message)
                .RaiseIn(this.BotBits);
        }

        private void HandleDisconnect(string message)
        {
            new DisconnectEvent(message)
                .RaiseIn(this.BotBits);
        }
    }
}