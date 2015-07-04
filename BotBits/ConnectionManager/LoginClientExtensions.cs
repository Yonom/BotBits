using System;
using System.Threading.Tasks;

namespace BotBits
{
    public static class LoginClientExtensions
    {
        public static LobbyItem[] GetLobby(this ILoginClient client)
        {
            return client.GetLobbyAsync().GetResultEx();
        }

        public static void CreateJoinRoom(this ILoginClient client, string worldId)
        {
            client.CreateJoinRoomAsync(worldId).WaitEx();
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

        public static DatabaseWorld LoadWorld(this ILoginClient client, string roomId)
        {
            return client.LoadWorldAsync(roomId).GetResultEx();
        }


        public static Task CreateOpenWorldAsync(this ILoginClient client, string name)
        {
            return client.CreateOpenWorldAsync("OW" + name, name);
        }



        public static Task JoinRoomAsync(this Task<LoginClient> client, string roomId)
        {
            return client.Then(task => task.Result.JoinRoomAsync(roomId)).ToSafeTask();
        }

        public static Task CreateJoinRoomAsync(this Task<LoginClient> client, string roomId) 
        {
            return client.Then(task => task.Result.CreateJoinRoomAsync(roomId)).ToSafeTask();
        }

        public static Task CreateOpenWorldAsync(this Task<LoginClient> client, string roomId, string name)
        {
            return client.Then(task => task.Result.CreateOpenWorldAsync(roomId, name)).ToSafeTask();
        }

        public static Task<LobbyItem[]> GetLobbyAsync(this Task<LoginClient> client)
        {
            return client.Then(task => task.Result.GetLobbyAsync()).ToSafeTask();
        }

        public static Task<DatabaseWorld> LoadWorldAsync(this Task<LoginClient> client, string roomId)
        {
            return client.Then(task => task.Result.LoadWorldAsync(roomId)).ToSafeTask();
        }
    }
}