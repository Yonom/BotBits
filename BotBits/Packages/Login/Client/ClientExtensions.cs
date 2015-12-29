using System.Linq;
using System.Threading.Tasks;
using PlayerIOClient;

namespace BotBits
{
    internal static class ClientExtensions
    {
        public static Task<LobbyItem[]> GetLobbyRoomsAsync(this Client client, ILoginClient loginClient, string roomType)
        {
            return client.Multiplayer
                .ListRoomsAsync(roomType, null, 0, 0)
                .Then(r => r.Result
                    .Select(room => new LobbyItem(loginClient, room))
                    .ToArray())
                .ToSafeTask();
        }
    }
}