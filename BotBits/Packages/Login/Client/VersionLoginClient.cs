using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using PlayerIOClient;

namespace BotBits
{
    public class VersionLoginClient : LoginClient
    {
        private const string EverybodyEdits = "Everybodyedits";
        private const string Beta = "Beta";

        internal VersionLoginClient([NotNull] IConnectionManager connectionManager, [NotNull] Client client, Task<PlayerData> argsAsync, int version)
            : base(connectionManager, client, argsAsync)
        {
            this.Version = version;
        }

        public int Version { get; }

        public override Task<LobbyItem[]> GetLobbyAsync()
        {
            var normals = this.Client.GetLobbyRoomsAsync(this, EverybodyEdits + this.Version);
            var betas = this.Client.GetLobbyRoomsAsync(this, Beta + this.Version);
            return Task.Factory
                .ContinueWhenAll(new[] { normals, betas }, items => items.SelectMany(i => i.Result).ToArray())
                .ToSafeTask();
        }

        public override Task CreateOpenWorldAsync(string roomId, string name)
        {
            if (!roomId.StartsWith("OW")) throw new ArgumentException("RoomId is not valid.", "roomId");

            var roomData = new Dictionary<string, string> { { "name", name } };

            return this.Client.Multiplayer
                .CreateJoinRoomAsync(roomId, EverybodyEdits + this.Version, true, roomData,
                    new Dictionary<string, string>())
                .Then(task => this.InitConnection(roomId, task.Result))
                .ToSafeTask();
        }

        public override Task CreateJoinRoomAsync(string roomId)
        {
            var roomPrefix = roomId.StartsWith("BW", StringComparison.OrdinalIgnoreCase)
                ? Beta
                : EverybodyEdits;

            return this.Client.Multiplayer
                .CreateJoinRoomAsync(roomId, roomPrefix + this.Version, true, null, null)
                .Then(task => this.InitConnection(roomId, task.Result))
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