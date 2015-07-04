using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using PlayerIOClient;

namespace BotBits
{
    internal static class ConnectionUtils
    {
        public static Task<ConnectionArgs> GetConnectionArgsAsync(Client client)
        {
            var args = new ConnectionArgs();
            var vaultTask = client.PayVault.RefreshAsync()
                .Then(task => args.ShopData = new ShopData(client.PayVault.Items));

             var playerObjectTask = client.BigDB.LoadMyPlayerObjectAsync()
                .Then(task => args.PlayerObject = new PlayerObject(task.Result));

            return vaultTask
                .Then(t => playerObjectTask)
                .Then(t => args)
                .ToSafeTask();
        }

        public static Task<Client> GuestLoginAsync(string gameId)
        {
            return PlayerIO.QuickConnect.SimpleConnectAsync(gameId, "guest", "guest", null);
        }

        public static Task<int> GetVersionAsync(Client client)
        {
            return client.BigDB.LoadAsync("config", "config")
                .Then(task => task.Result.GetInt("version"))
                .ToSafeTask();
        }

        public static Task<Client> ArmorGamesRoomLoginAsync(string gameId, string userId, string token)
        {
            return PlayerIOAsync.AuthenticateAsync(
                gameId,
                "secure",
                new Dictionary<string, string>
                {
                    {"userId", userId},
                    {"authToken", token}
                },
                null);
        }
    }
}
