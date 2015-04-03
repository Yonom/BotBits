using System;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using PlayerIOClient;

namespace BotBits
{
    public sealed class LoginClient
    {
        private const string EverybodyEdits = "Everybodyedits";
        private const string Beta = "Beta";

        [NotNull]
        private readonly IConnectionManager<LoginClient> _connectionManager;

        private readonly Task<ConnectionArgs> _argsAsync;

        public LoginClient([NotNull] IConnectionManager<LoginClient> connectionManager, [NotNull] Client client)
        {
            if (connectionManager == null) throw new ArgumentNullException("connectionManager");
            if (client == null) throw new ArgumentNullException("client");
            this._connectionManager = connectionManager;
            this.Client = client;

            this._argsAsync = ConnectionUtils.GetConnectionArgsAsync(this.Client);
        }

        [NotNull]
        public Client Client { get; private set; }

        public LobbyItem[] GetLobby()
        {
            return this.GetLobbyAsync().GetResultEx();
        }

        public Task<LobbyItem[]> GetLobbyAsync()
        {
            return this.GetVersionAsync().Then(task =>
            {
                var version = task.Result;
                var normals = this.GetLobbyRoomsAsync(EverybodyEdits + version);
                var betas = this.GetLobbyRoomsAsync(Beta + version);
                return Task.Factory.ContinueWhenAll(new[] {normals, betas},
                    items => items.SelectMany(i => i.Result).ToArray());
            }).ToSafeTask();
        }

        private Task<LobbyItem[]> GetLobbyRoomsAsync(string roomId)
        {
            return this.Client.Multiplayer
                .ListRoomsAsync(roomId, null, 0, 0)
                .Then(r => r.Result
                    .Select(room => new LobbyItem(this, room))
                    .ToArray())
                .ToSafeTask();
        }

        public void CreateJoinRoom(string worldId)
        {
            this.CreateJoinRoomAsync(worldId).WaitEx();
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

        public void JoinRoom(string roomId)
        {
            this.JoinRoomAsync(roomId).WaitEx();
        }

        public Task JoinRoomAsync(string roomId)
        {
            return this.Client.Multiplayer
                .JoinRoomAsync(roomId, null)
                .Then(task => this.InitConnection(task.Result))
                .ToSafeTask();
        }

        private Task<int> GetVersionAsync()
        {
            return this.Client.BigDB.LoadAsync("config", "config")
                .Then(task => task.Result.GetInt("version"));
        }

        private Task InitConnection(Connection conn)
        {
            return this._argsAsync.Then(task => this._connectionManager.AttachConnection(conn, task.Result));
        }
    }
}