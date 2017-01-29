using System;
using System.Threading;
using System.Threading.Tasks;

namespace BotBits
{
    public static class LoginClientExtensions
    {
        // async ct
        public static Task CreateOpenWorldAsync(this ILoginClient client, string name, CancellationToken ct)
        {
            return client.CreateOpenWorldAsync("OW" + GenerateUniqueRoomId(name), name, ct);
        }

        // nonasync ct
        public static void CreateJoinRoom(this ILoginClient client, string roomId, CancellationToken ct)
        {
            client.CreateJoinRoomAsync(roomId, ct).WaitEx();
        }

        public static void JoinRoom(this ILoginClient client, string roomId, CancellationToken ct)
        {
            client.JoinRoomAsync(roomId, ct).WaitEx();
        }

        public static void CreateOpenWorld(this ILoginClient client, string roomId, string name, CancellationToken ct)
        {
            client.CreateOpenWorldAsync(roomId, name, ct).WaitEx();
        }

        public static void CreateOpenWorld(this ILoginClient client, string name, CancellationToken ct)
        {
            client.CreateOpenWorldAsync(name, ct).WaitEx();
        }

        // async
        public static Task CreateJoinRoomAsync(this ILoginClient client, string roomId)
        {
            return client.CreateJoinRoomAsync(roomId, CancellationToken.None);
        }

        public static Task JoinRoomAsync(this ILoginClient client, string roomId)
        {
            return client.JoinRoomAsync(roomId, CancellationToken.None);
        }

        public static Task CreateOpenWorldAsync(this ILoginClient client, string roomId, string name)
        {
            return client.CreateOpenWorldAsync(roomId, name, CancellationToken.None);
        }
        
        public static Task CreateOpenWorldAsync(this ILoginClient client, string name)
        {
            return client.CreateOpenWorldAsync(name, CancellationToken.None);
        }

        // nonasync
        public static void CreateJoinRoom(this ILoginClient client, string roomId)
        {
            client.CreateJoinRoomAsync(roomId).WaitEx();
        }

        public static void JoinRoom(this ILoginClient client, string roomId)
        {
            client.JoinRoomAsync(roomId).WaitEx();
        }

        public static void CreateOpenWorld(this ILoginClient client, string roomId, string name)
        {
            client.CreateOpenWorldAsync(roomId, name).WaitEx();
        }

        public static void CreateOpenWorld(this ILoginClient client, string name)
        {
            client.CreateOpenWorldAsync(name).WaitEx();
        }

        public static LobbyItem[] GetLobby(this ILoginClient client)
        {
            return client.GetLobbyAsync().GetResultEx();
        }

        public static DatabaseWorld LoadWorld(this ILoginClient client, string roomId)
        {
            return client.LoadWorldAsync(roomId).GetResultEx();
        }

        public static VersionLoginClient WithAutomaticVersion(this LoginClient client)
        {
            return client.WithAutomaticVersionAsync().GetResultEx();
        }

        // task async tc
        public static Task JoinRoomAsync(this Task<LoginClient> client, string roomId, CancellationToken ct)
        {
            return client.Then(task => task.Result.JoinRoomAsync(roomId, ct)).ToSafeTask();
        }

        public static Task CreateJoinRoomAsync(this Task<LoginClient> client, string roomId, CancellationToken ct)
        {
            return client.Then(task => task.Result.CreateJoinRoomAsync(roomId, ct)).ToSafeTask();
        }

        public static Task CreateOpenWorldAsync(this Task<LoginClient> client, string roomId, string name, CancellationToken ct)
        {
            return client.Then(task => task.Result.CreateOpenWorldAsync(roomId, name, ct)).ToSafeTask();
        }

        public static Task CreateOpenWorldAsync(this Task<LoginClient> client, string name, CancellationToken ct)
        {
            return client.Then(task => task.Result.CreateOpenWorldAsync(name, ct)).ToSafeTask();
        }

        // task async
        public static Task JoinRoomAsync(this Task<LoginClient> client, string roomId)
        {
            return client.JoinRoomAsync(roomId, CancellationToken.None);
        }

        public static Task CreateJoinRoomAsync(this Task<LoginClient> client, string roomId)
        {
            return client.CreateJoinRoomAsync(roomId, CancellationToken.None);
        }

        public static Task CreateOpenWorldAsync(this Task<LoginClient> client, string roomId, string name)
        {
            return client.CreateOpenWorldAsync(roomId, name, CancellationToken.None);
        }

        public static Task CreateOpenWorldAsync(this Task<LoginClient> client, string name)
        {
            return client.CreateOpenWorldAsync(name, CancellationToken.None);
        }

        public static Task<LobbyItem[]> GetLobbyAsync(this Task<LoginClient> client)
        {
            return client.Then(task => task.Result.GetLobbyAsync()).ToSafeTask();
        }

        public static Task<DatabaseWorld> LoadWorldAsync(this Task<LoginClient> client, string roomId)
        {
            return client.Then(task => task.Result.LoadWorldAsync(roomId)).ToSafeTask();
        }
        
        // helpers
        private static string GenerateUniqueRoomId(string str)
        {
            return StringUtils.DecimalToArbitrarySystem(
                (((int)new Random().NextDouble() * 1000 >> 0) + DateTime.UtcNow.Millisecond), 36)
                   + " " + str;
        }
    }
}