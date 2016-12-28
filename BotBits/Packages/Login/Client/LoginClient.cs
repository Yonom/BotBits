using System;
using System.Threading.Tasks;
using EE.FutureProof;
using JetBrains.Annotations;
using PlayerIOClient;

namespace BotBits
{
    public class LoginClient : ILoginClient
    {
        private readonly Task<PlayerData> _argsAsync;

        [NotNull]
        private readonly ConnectionManager _connectionManager;

        internal LoginClient([NotNull] ConnectionManager connectionManager, [NotNull] Client client)
        {
            if (connectionManager == null)
                throw new ArgumentNullException(nameof(connectionManager));
            if (client == null)
                throw new ArgumentNullException(nameof(client));
            this._connectionManager = connectionManager;
            this.Client = client;

            this._argsAsync = LoginUtils.GetConnectionArgsAsync(client);
        }

        public string ConnectUserId => this.Client.ConnectUserId;

        [NotNull]
        public Client Client { get; }

        public Task<LobbyItem[]> GetLobbyAsync()
        {
            return this.WithAutomaticVersionAsync()
                .Then(task => task.Result.GetLobbyAsync())
                .ToSafeTask();
        }

        public Task CreateOpenWorldAsync(string roomId, string name)
        {
            return this.WithAutomaticVersionAsync()
                .Then(task => task.Result.CreateOpenWorldAsync(roomId, name))
                .ToSafeTask();
        }

        public Task CreateJoinRoomAsync(string roomId)
        {
            return this.WithAutomaticVersionAsync()
                .Then(task => task.Result.CreateJoinRoomAsync(roomId))
                .ToSafeTask();
        }

        public Task JoinRoomAsync(string roomId)
        {
            return this.Client.Multiplayer
                .JoinRoomAsync(roomId, null)
                .Then(task => this.InitConnection(roomId, null, task.Result))
                .ToSafeTask();
        }

        public Task<DatabaseWorld> LoadWorldAsync(string roomId)
        {
            return this.Client.BigDB.LoadAsync("Worlds", roomId)
                .Then(t => DatabaseWorld.FromDatabaseObject(t.Result))
                .ToSafeTask();
        }

        public VersionLoginClient WithVersion(int version)
        {
            return new VersionLoginClient(this, version);
        }

        public Task<VersionLoginClient> WithAutomaticVersionAsync()
        {
            return LoginUtils.GetVersionAsync(this.Client)
                .Then(task => this.WithVersion(task.Result))
                .ToSafeTask();
        }

        internal Task InitConnection(string roomId, int? version, Connection conn)
        {
            return this._argsAsync
                .Then(task => this.Attach(this._connectionManager, conn, 
                    new ConnectionArgs(this.ConnectUserId, roomId, task.Result), version))
                .ToSafeTask();
        }

        protected virtual Task Attach(ConnectionManager connectionManager, Connection connection, ConnectionArgs args, int? version)
        {
            connectionManager.AttachConnection(connection, args);
            return TaskHelper.FromResult(true);
        }
    }
}