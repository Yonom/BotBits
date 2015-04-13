using System;
using System.Collections.Generic;
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
                .Then(task =>
                    args.ShopData = new ShopData(client.PayVault.Items));

             var playerObjectTask = client.BigDB.LoadMyPlayerObjectAsync()
                .Then(task => args.PlayerObject = new PlayerObject(task.Result));

            return vaultTask.Then(t => playerObjectTask).Then(t => args);
        }

        public static Task<Client> GuestLoginAsync(string gameId)
        {
            return PlayerIO.QuickConnect.SimpleConnectAsync(gameId, "guest", "guest", null);
        }

        public static Task<Client> ArmorGamesRoomLoginAsync(string gameId, string userId, string token)
        {
            return GuestLoginAsync(gameId)
                .Then(t => t.Result.Multiplayer.JoinRoomAsync(String.Empty, null)
                .Then(task =>
                {
                    var guestConn = task.Result;
                    var tcs = new TaskCompletionSource<Client>();
                    guestConn.OnMessage += (sender, message) =>
                    {
                        try
                        {
                            if (message.Type != "auth" || message.Count < 2)
                                throw new ArgumentException("Auth failed.");

                            tcs.TrySetResult(PlayerIO.Authenticate(
                                gameId,
                                "secure",
                                new Dictionary<string, string>
                                {
                                    {"userId", message.GetString(0)},
                                    {"auth", message.GetString(1)}
                                }, 
                                null));
                        }
                        catch (Exception ex)
                        {
                            tcs.TrySetException(ex);
                        }
                        finally
                        {
                            guestConn.Disconnect();
                        }
                    };
                    guestConn.OnDisconnect += (sender, message) =>
                        tcs.TrySetException(new ArgumentException("Auth failed."));
                    if (guestConn.Connected)
                        guestConn.Send("auth", userId, token);
                    else
                        tcs.TrySetException(new ArgumentException("Auth failed."));
                    return tcs.Task;
                }));
        }
    }
}
