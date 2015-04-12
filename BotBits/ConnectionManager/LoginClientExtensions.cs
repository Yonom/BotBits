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

        public static DatabaseWorld LoadWorld(this ILoginClient client, string roomId)
        {
            return client.LoadWorldAsync(roomId).GetResultEx();
        }
    }
}