using System.Collections.Generic;
using System.Threading.Tasks;
using PlayerIOClient;

namespace BotBits
{
    internal static class LoginUtils
    {
        public static Task<PlayerData> GetPlayerDataAsync(DatabaseHandle handle)
        {
            var shopTask = handle.GetMyShopDataAsync();
            //var playerObjectTask = handle.GetMyPlayerObjectAsync();
            var playerObject = new PlayerObject();
            return shopTask
                .Then(t => new PlayerData(playerObject, t.Result))
                .ToSafeTask(); ;
        }

        public static Task<Client> GuestLoginAsync(string gameId)
        {
            return PlayerIO.QuickConnect.SimpleConnectAsync(gameId, "guest", "guest", null);
        }

        public static Task<Client> ArmorGamesRoomLoginAsync(string gameId, string userId, string token)
        {
            return PlayerIOAsync.AuthenticateAsync(
                gameId,
                "secure",
                new Dictionary<string, string>
                {
                    { "userId", userId },
                    { "authToken", token }
                },
                null);
        }
    }
}