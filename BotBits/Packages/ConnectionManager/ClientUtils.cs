using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlayerIOClient;

namespace BotBits
{
    public static class ClientUtils
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
