using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using PlayerIOClient;

namespace BotBits
{
    public class LoginClient : ILoginClient
    {
        [NotNull]
        private readonly IConnectionManager _connectionManager;

        private readonly Task<ConnectionArgs> _argsAsync;

        internal LoginClient([NotNull] IConnectionManager connectionManager, [NotNull] Client client)
            : this(connectionManager, client, ConnectionUtils.GetConnectionArgsAsync(client))
        {
        }

        internal LoginClient([NotNull] IConnectionManager connectionManager, [NotNull] Client client,
            Task<ConnectionArgs> argsAsync)
        {
            if (connectionManager == null) throw new ArgumentNullException("connectionManager");
            if (client == null) throw new ArgumentNullException("client");
            this._connectionManager = connectionManager;
            this.Client = client;

            this._argsAsync = argsAsync;
        }

        [NotNull]
        public Client Client { get; private set; }

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
                .Then(task => this.InitConnection(task.Result))
                .ToSafeTask();
        }

        public virtual Task<DatabaseWorld> LoadWorldAsync(string roomId)
        {
            return this.Client.BigDB.LoadAsync("Worlds", roomId)
                .Then(t => DatabaseWorld.FromDatabaseObject(t.Result))
                .ToSafeTask();
        }

        public virtual VersionLoginClient WithVersion(int version)
        {
            return new VersionLoginClient(this._connectionManager, this.Client, this._argsAsync, version);
        }

        public virtual Task<VersionLoginClient> WithAutomaticVersionAsync()
        {
            return ConnectionUtils.GetVersionAsync(this.Client)
                .Then(task => this.WithVersion(task.Result))
                .ToSafeTask();
        }

        protected Task InitConnection(Connection conn)
        {
            return this._argsAsync
                .Then(task => this._connectionManager.AttachConnection(conn, task.Result))
                .ToSafeTask();
        }
    }

    public class VersionLoginClient : LoginClient
    {
        private const string EverybodyEdits = "Everybodyedits";
        private const string Beta = "Beta";

        public int Version { get; private set; }

        internal VersionLoginClient([NotNull] IConnectionManager connectionManager, [NotNull] Client client,
            Task<ConnectionArgs> argsAsync, int version)
            : base(connectionManager, client, argsAsync)
        {
            this.Version = version;
        }
        public override Task<LobbyItem[]> GetLobbyAsync()
        {
            var normals = this.Client.GetLobbyRoomsAsync(this, EverybodyEdits + this.Version);
            var betas = this.Client.GetLobbyRoomsAsync(this, Beta + this.Version);
            return Task.Factory
                .ContinueWhenAll(new[] {normals, betas}, items => items.SelectMany(i => i.Result).ToArray())
                .ToSafeTask();
        }

        public override Task CreateOpenWorldAsync(string roomId, string name)
        {
            if (!roomId.StartsWith("OW"))
                throw new ArgumentException("RoomId is not valid.", "roomId");

            var roomData = new Dictionary<string, string> { { "name", name } };

            return this.Client.Multiplayer
                .CreateJoinRoomAsync(roomId, EverybodyEdits + this.Version, true, roomData, new Dictionary<string, string>())
                .Then(task => this.InitConnection(task.Result))
                .ToSafeTask();
        }

        public override Task CreateJoinRoomAsync(string roomId)
        {
            var roomPrefix = roomId.StartsWith("BW", StringComparison.OrdinalIgnoreCase)
                ? Beta
                : EverybodyEdits;

            return this.Client.Multiplayer
                .CreateJoinRoomAsync(roomId, roomPrefix + this.Version, true, null, null)
                .Then(task => this.InitConnection(task.Result))
                .ToSafeTask();
        }

        public override Task<VersionLoginClient> WithAutomaticVersionAsync()
        {
            var taskSource = new TaskCompletionSource<VersionLoginClient>();
            taskSource.SetResult(this);
            return taskSource.Task;
        }
    }
}