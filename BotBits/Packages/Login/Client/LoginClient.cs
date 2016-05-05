using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using PlayerIOClient;

namespace BotBits
{
    public class LoginClient : ILoginClient
    {
        private readonly Task<PlayerData> _argsAsync;

        [NotNull]
        private readonly IConnectionManager _connectionManager;

        internal LoginClient([NotNull] IConnectionManager connectionManager, [NotNull] Client client)
            : this(connectionManager, client, LoginUtils.GetConnectionArgsAsync(client))
        {
        }

        internal LoginClient([NotNull] IConnectionManager connectionManager, [NotNull] Client client, Task<PlayerData> argsAsync)
        {
            if (connectionManager == null) throw new ArgumentNullException("connectionManager");
            if (client == null) throw new ArgumentNullException("client");
            this._connectionManager = connectionManager;
            this.Client = client;

            this._argsAsync = argsAsync;
        }

        public string ConnectUserId => this.Client.ConnectUserId;

        [NotNull]
        public Client Client { get; }

        public virtual Task<LobbyItem[]> GetLobbyAsync()
        {
            return this.WithAutomaticVersionAsync()
                .Then(task => task.Result.GetLobbyAsync())
                .ToSafeTask();
        }

        public virtual Task CreateOpenWorldAsync(string roomId, string name)
        {
            return this.WithAutomaticVersionAsync()
                .Then(task => task.Result.CreateOpenWorldAsync(roomId, name))
                .ToSafeTask();
        }

        public virtual Task CreateJoinRoomAsync(string roomId)
        {
            return this.WithAutomaticVersionAsync()
                .Then(task => task.Result.CreateJoinRoomAsync(roomId))
                .ToSafeTask();
        }

        public virtual Task JoinRoomAsync(string roomId)
        {
            return this.Client.Multiplayer
                .JoinRoomAsync(roomId, null)
                .Then(task => this.InitConnection(roomId, task.Result))
                .ToSafeTask();
        }

        public virtual Task<DatabaseWorld> LoadWorldAsync(string roomId)
        {
            return this.Client.BigDB.LoadAsync("Worlds", roomId)
                .Then(t => DatabaseWorld.FromDatabaseObject(t.Result))
                .ToSafeTask();
        }

        public VersionLoginClient WithVersion(int version)
        {
            return new VersionLoginClient(this._connectionManager, this.Client, this._argsAsync, version);
        }

        public virtual Task<VersionLoginClient> WithAutomaticVersionAsync()
        {
            return LoginUtils.GetVersionAsync(this.Client)
                .Then(task => this.WithVersion(task.Result))
                .ToSafeTask();
        }

        protected Task InitConnection(string roomId, Connection conn)
        {
            return this._argsAsync
                .Then(task => this._connectionManager.SetConnection(conn, new ConnectionArgs(this.ConnectUserId, roomId, task.Result)))
                .ToSafeTask();
        }
    }
}