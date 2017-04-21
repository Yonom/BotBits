using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using PlayerIOClient;

namespace BotBits
{
    public class DatabaseHandle
    {
        public static DatabaseHandle Default => new DatabaseHandle(PlayerIOServices.DefaultClient);

        public Client Client { get; }

        public DatabaseHandle(Client client)
        {
            this.Client = client;
        }
        
        // World

        public Task<DatabaseWorld> GetWorldAsync(string roomId)
        {
            return this.Client.BigDB.LoadAsync("Worlds", roomId)
                .Then(t => DatabaseWorld.FromDatabaseObject(t.Result))
                .ToSafeTask();
        }

        public DatabaseWorld GetWorld(string roomId)
        {
            return this.GetWorldAsync(roomId).GetResultEx();
        }

        // Worlds

        public Task<DatabaseWorld[]> GetWorldsAsync(params string[] roomIds)
        {
            return this.Client.BigDB.LoadKeysAsync("Worlds", roomIds)
                .Then(t => t.Result.Select(DatabaseWorld.FromDatabaseObject).ToArray())
                .ToSafeTask();
        }

        public DatabaseWorld[] GetWorlds(params string[] roomIds)
        {
            return this.GetWorldsAsync(roomIds).GetResultEx();
        }

        // PlayerObject

        public Task<PlayerObject> GetPlayerObjectAsync(string userId)
        {
            return this.Client.BigDB.LoadAsync("PlayerObjects", userId)
                .Then(task => new PlayerObject(task.Result))
                .ToSafeTask();
        }

        public PlayerObject GetPlayerObject(string userId)
        {
            return this.GetPlayerObjectAsync(userId).GetResultEx();
        }

        // PlayerObjectByUsername

        public Task<PlayerObject> GetPlayerObjectByUsernameAsync(string username)
        {
            return this.Client.BigDB.LoadSingleAsync("PlayerObjects", "name", username)
                .Then(task => new PlayerObject(task.Result))
                .ToSafeTask();
        }

        public PlayerObject GetPlayerObjectByUsername(string username)
        {
            return this.GetPlayerObjectByUsernameAsync(username).GetResultEx();
        }

        // PlayerObjects

        public Task<PlayerObject[]> GetPlayerObjectsAsync(params string[] userids)
        {
            return this.Client.BigDB.LoadKeysAsync("PlayerObjects", userids)
                .Then(task => task.Result.Select(o => new PlayerObject(o)).ToArray())
                .ToSafeTask();
        }

        public PlayerObject[] GetPlayerObjects(params string[] userids)
        {
            return this.GetPlayerObjectsAsync(userids).GetResultEx();
        }

        // MyPlayerObject

        public Task<PlayerObject> GetMyPlayerObjectAsync()
        {
            return this.Client.BigDB.LoadMyPlayerObjectAsync()
                .Then(task => new PlayerObject(task.Result))
                .ToSafeTask();
        }

        public PlayerObject GetMyPlayerObject()
        {
            return this.GetMyPlayerObjectAsync().GetResultEx();
        }

        // MyShopData

        public Task<ShopData> GetMyShopDataAsync()
        {
            return this.Client.PayVault.RefreshAsync()
                .Then(task => new ShopData(this.Client.PayVault.Items))
                .ToSafeTask();
        }

        public ShopData GetMyShopData()
        {
            return this.GetMyShopDataAsync().GetResultEx();
        }
        
        // MyAchievements

        public Task<AchievementData> GetMyAchievementsAsync()
        {
            return this.Client.Achievements.RefreshAsync()
                .Then(task => new AchievementData(this.Client.Achievements.MyAchievements))
                .ToSafeTask();
        }

        public AchievementData GetMyAchievements()
        {
            return this.GetMyAchievementsAsync().GetResultEx();
        }
        
        // UsernameData

        public Task<UsernameData> GetUsernameDataAsync(string username)
        {
            return this.Client.BigDB.LoadAsync("Usernames", username)
                .Then(task => new UsernameData(task.Result))
                .ToSafeTask();
        }

        public UsernameData GetUsernameData(string username)
        {
            return this.GetUsernameDataAsync(username).GetResultEx();
        }

        // UsernameDatas

        public Task<UsernameData[]> GetUsernameDatasAsync(params string[] usernames)
        {
            return this.Client.BigDB.LoadKeysAsync("Usernames", usernames)
                .Then(task => task.Result.Select(o => new UsernameData(o)).ToArray())
                .ToSafeTask();
        }

        public UsernameData[] GetUsernameDatas(params string[] usernames)
        {
            return this.GetUsernameDatasAsync(usernames).GetResultEx();
        }

        // UsernameDataByUserId

        public Task<UsernameData> GetUsernameDataByUserIdAsync(string userId)
        {
            return this.Client.BigDB.LoadSingleAsync("Usernames", "owner", userId)
                .Then(task => new UsernameData(task.Result))
                .ToSafeTask();
        }

        public UsernameData GetUsernameDataByUserId(string userId)
        {
            return this.GetUsernameDataAsync(userId).GetResultEx();
        }

        // VersionData

        public Task<VersionData> GetVersionDataAsync()
        {
            return this.Client.BigDB.LoadAsync("Config", "config")
                .Then(task => new VersionData(task.Result))
                .ToSafeTask();
        }

        public VersionData GetVersionData()
        {
            return this.GetVersionDataAsync().GetResultEx();
        }

        // StaffRoles

        public Task<StaffRoleData[]> GetStaffRolesAsync()
        {
            return this.Client.BigDB.LoadAsync("Config", "staff")
                .Then(task => StaffRoleData.GetStaffRoles(task.Result))
                .ToSafeTask();
        }

        public StaffRoleData[] GetStaffRoles()
        {
            return this.GetStaffRolesAsync().GetResultEx();
        }
    }
}
