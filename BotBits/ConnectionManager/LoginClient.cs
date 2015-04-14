using System;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using PlayerIOClient;

namespace BotBits
{
    public sealed class LoginClient : ILoginClient
    {
        private const string EverybodyEdits = "Everybodyedits";
        private const string Beta = "Beta";

        [NotNull]
        private readonly IConnectionManager _connectionManager;

        private readonly Task<ConnectionArgs> _argsAsync;

        public LoginClient([NotNull] IConnectionManager connectionManager, [NotNull] Client client)
        {
            if (connectionManager == null) throw new ArgumentNullException("connectionManager");
            if (client == null) throw new ArgumentNullException("client");
            this._connectionManager = connectionManager;
            this.Client = client;

            this._argsAsync = ConnectionUtils.GetConnectionArgsAsync(this.Client);
        }

        [NotNull]
        public Client Client { get; private set; }

        public Task<LobbyItem[]> GetLobbyAsync()
        {
            return this.GetVersionAsync().Then(task =>
            {
                var version = task.Result;
                var normals = this.Client.GetLobbyRoomsAsync(this, EverybodyEdits + version);
                var betas = this.Client.GetLobbyRoomsAsync(this, Beta + version);
                return Task.Factory.ContinueWhenAll(new[] {normals, betas},
                    items => items.SelectMany(i => i.Result).ToArray());
            }).ToSafeTask();
        }

        public Task CreateJoinRoomAsync(string roomId)
        {
            var roomPrefix = roomId.StartsWith("BW", StringComparison.OrdinalIgnoreCase)
                ? Beta
                : EverybodyEdits;

            return this.GetVersionAsync()
                .Then(task => this.Client.Multiplayer
                    .CreateJoinRoomAsync(roomId, roomPrefix + task.Result, true, null, null))
                .Then(task => this.InitConnection(task.Result))
                .ToSafeTask();
        }

        public Task JoinRoomAsync(string roomId)
        {
            return this.Client.Multiplayer
                .JoinRoomAsync(roomId, null)
                .Then(task => this.InitConnection(task.Result))
                .ToSafeTask();
        }

        public Task<DatabaseWorld> LoadWorldAsync(string roomId)
        {
            return this.Client.BigDB.LoadAsync("Worlds", roomId)
                .Then(t => DatabaseWorld.FromDatabaseObject(t.Result));
        }

        private Task<int> GetVersionAsync()
        {
            return ConnectionUtils.GetVersionAsync(this.Client); 
        }

        private Task InitConnection(Connection conn)
        {
            return this._argsAsync.Then(task => this._connectionManager.AttachConnection(conn, task.Result));
        }
    }
}