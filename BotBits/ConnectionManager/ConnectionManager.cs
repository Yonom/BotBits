using System;
using System.Threading;
using System.Threading.Tasks;
using BotBits.Annotations;
using BotBits.Events;
using PlayerIOClient;

namespace BotBits
{
    public sealed class ConnectionManager : Package<ConnectionManager>, IDisposable
    {
        private const string GameId = "everybody-edits-su9rn58o40itdbnw69plyw";
        private Connection _connection;

        public Connection Connection
        {
            get { return this._connection; }
        }

        [Obsolete("Invalid to use \"new\" on this class. Use the static .Of(botBits) method instead.", true)]
        public ConnectionManager()
        {
        }

        void IDisposable.Dispose()
        {
            if (this.Connection != null)
                this.Connection.Disconnect();
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
        public Task<LoginClient> EmailLoginAsync(string email, string password)
        {
            var tcs = new TaskCompletionSource<LoginClient>();
            PlayerIO.QuickConnect.SimpleConnect(GameId, email, password, null,
                cl => tcs.SetResult(this.WithClient(cl)),
                tcs.SetException);
            return tcs.Task;
        }

        [Pure]
        public Task<LoginClient> FacebookLoginAsync(string token)
        {
            var tcs = new TaskCompletionSource<LoginClient>();
            PlayerIO.QuickConnect.FacebookOAuthConnect(GameId, token, null, null,
                cl => tcs.SetResult(this.WithClient(cl)),
                tcs.SetException);
            return tcs.Task;
        }

        [Pure]
        public Task<LoginClient> KongregateLoginAsync(string userId, string token)
        {
            var tcs = new TaskCompletionSource<LoginClient>();
            PlayerIO.QuickConnect.KongregateConnect(GameId, userId, token, null,
                cl => tcs.SetResult(this.WithClient(cl)),
                tcs.SetException);
            return tcs.Task;
        }

        [Pure]
        public Task<LoginClient> ArmorGamesLoginAsync(string userId, string token)
        {
            return this.EmailLoginAsync("guest", "guest").ContinueWith(t =>
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
            if (client == null)
                throw new ArgumentNullException("client");

            return new LoginClient(this, client);
        }

        public void SetConnection([NotNull] Connection connection)
        {
            if (connection == null)
                throw new ArgumentNullException("connection");

            if (Interlocked.CompareExchange(ref this._connection, connection, null) != null)
            {
                throw new InvalidOperationException("A connection has already been established.");
            }

            new ConnectEvent()
                .RaiseIn(this.BotBits);

            this.Connection.OnDisconnect += this.Connection_OnDisconnect;
            if (!this.Connection.Connected)
                this.HandleDisconnect(String.Empty);
        }

        private void Connection_OnDisconnect(object sender, string message)
        {
            this.BotBits.Schedule(() => 
                this.HandleDisconnect(message)).Wait();
        }

        private void HandleDisconnect(string message)
        {
            new DisconnectEvent(message)
                .RaiseIn(this.BotBits);
        }

        public sealed class LoginClient
        {
            [NotNull]
            private readonly ConnectionManager _connectionManager;

            public LoginClient([NotNull] ConnectionManager connectionManager, [NotNull] Client client)
            {
                if (connectionManager == null) throw new ArgumentNullException("connectionManager");
                if (client == null) throw new ArgumentNullException("client");
                this._connectionManager = connectionManager;
                this.Client = client;
            }

            [NotNull]
            public Client Client { get; private set; }

            public void CreateJoinRoom(string worldId)
            {
                this.CreateJoinRoomAsync(worldId).Wait();
            }

            public Task CreateJoinRoomAsync(string roomId)
            {
                var roomPrefix = roomId.StartsWith("BW", StringComparison.OrdinalIgnoreCase)
                    ? "Beta"
                    : "Everybodyedits";

                var tcs = new TaskCompletionSource<bool>();

                this.Client.BigDB.Load("config", "config", dbo =>
                {
                    try
                    {
                        var serverVersion = dbo["version"];
                        this.Client.Multiplayer.CreateJoinRoom(roomId,
                            roomPrefix + serverVersion, true, null, null, conn =>
                            {
                                try
                                {
                                    this._connectionManager.SetConnection(conn);
                                    tcs.SetResult(true);
                                }
                                catch (Exception ex)
                                {
                                    tcs.SetException(ex);
                                }
                            }, tcs.SetException);
                    }
                    catch (Exception ex)
                    {
                        tcs.SetException(ex);
                    }
                }, tcs.SetException);

                return tcs.Task;
            }
            
            public void JoinRoom(string worldId)
            {
                this.JoinRoomAsync(worldId).Wait();
            }

            public Task JoinRoomAsync(string roomId)
            {
                var tcs = new TaskCompletionSource<bool>();

                this.Client.Multiplayer.JoinRoom(roomId, null, conn =>
                {
                    try
                    {
                        this._connectionManager.SetConnection(conn);
                        tcs.SetResult(true);
                    }
                    catch (Exception ex)
                    {
                        tcs.SetException(ex);
                    }
                }, tcs.SetException);

                return tcs.Task;
            }
        }
    }
}