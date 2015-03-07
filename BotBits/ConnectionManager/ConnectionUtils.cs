using System.Threading.Tasks;
using PlayerIOClient;

namespace BotBits
{
    class ConnectionUtils
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
    }
}
