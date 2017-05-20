using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
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

        // --- Shop ---

        // MyShopData

        public Task<ShopData> GetMyShopDataAsync()
        {
            return this.Client.PayVault.RefreshAsync()
                .Then(task => new ShopData(this.Client.PayVault.Coins, this.Client.PayVault.Items))
                .ToSafeTask();
        }

        public ShopData GetMyShopData()
        {
            return this.GetMyShopDataAsync().GetResultEx();
        }

        /// -- Achievements ---

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

        // --- PlayerObjects ---

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

        // PlayerObjectByOldUsername
        
        public Task<PlayerObject> GetPlayerObjectByOldUsernameAsync(string oldUsername)
        {
            return this.Client.BigDB.LoadSingleAsync("PlayerObjects", "oldname", oldUsername)
                .Then(task => new PlayerObject(task.Result))
                .ToSafeTask();
        }

        public PlayerObject GetPlayerObjectByOldUsername(string oldUsername)
        {
            return this.GetPlayerObjectByOldUsernameAsync(oldUsername).GetResultEx();
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

        // --- Usernames ---
        
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

        // OldUsernameDataByUserId

        public Task<UsernameData> GetOldUsernameDataByUserIdAsync(string userId)
        {
            return this.Client.BigDB.LoadSingleAsync("Usernames", "oldowner", userId)
                .Then(task => new UsernameData(task.Result))
                .ToSafeTask();
        }

        public UsernameData GetOldUsernameDataByUserId(string userId)
        {
            return this.GetOldUsernameDataByUserIdAsync(userId).GetResultEx();
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

        // --- World ---

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

        // WorldsByCrew

        public Task<DatabaseWorld[]> GetWorldsByCrewAsync(Crew crew, int limit = int.MaxValue)
        {
            return DatabaseUtils.RecursiveLoadRangeAsync(this.Client, "Worlds", "ByCrew", null, crew.Id, crew.Id, limit, dbo => dbo.GetString("Crew"))
                .Then(t => t.Result.Select(DatabaseWorld.FromDatabaseObject).ToArray())
                .ToSafeTask();
        }

        public DatabaseWorld[] GetWorldsByCrew(Crew crew, int limit = int.MaxValue)
        {
            return this.GetWorldsByCrewAsync(crew, limit).GetResultEx();
        }

        // WorldsByOwner

        public Task<DatabaseWorld[]> GetWorldsByOwnerAsync(string ownerUserId, int limit = int.MaxValue)
        {
            return DatabaseUtils.RecursiveLoadRangeAsync(this.Client, "Worlds", "owner", null, ownerUserId, ownerUserId, limit, dbo => dbo.GetString("owner"))
                .Then(t => t.Result.Select(DatabaseWorld.FromDatabaseObject).ToArray())
                .ToSafeTask();
        }

        public DatabaseWorld[] GetWorldsByOwner(string ownerUserId, int limit = int.MaxValue)
        {
            return this.GetWorldsByOwnerAsync(ownerUserId, limit).GetResultEx();
        }

        // WorldsByName

        public Task<DatabaseWorld[]> GetWorldsByNameAsync(string name, int limit = int.MaxValue)
        {
            return DatabaseUtils.RecursiveLoadRangeAsync(this.Client, "Worlds", "name", null, name, name, limit, dbo => dbo.GetString("name"))
                .Then(t => t.Result.Select(DatabaseWorld.FromDatabaseObject).ToArray())
                .ToSafeTask();
        }

        public DatabaseWorld[] GetWorldsByName(string name, int limit = int.MaxValue)
        {
            return this.GetWorldsByNameAsync(name, limit).GetResultEx();
        }

        // WorldsByPlays

        public Task<DatabaseWorld[]> GetWorldsByPlaysAsync(int minPlays, int maxPlays, int limit = int.MaxValue)
        {
            return DatabaseUtils.RecursiveLoadRangeAsync(this.Client, "Worlds", "plays", null, maxPlays, minPlays, limit, dbo => dbo.GetString("plays"))
                .Then(t => t.Result.Select(DatabaseWorld.FromDatabaseObject).ToArray())
                .ToSafeTask();
        }

        public DatabaseWorld[] GetWorldsByPlays(int minPlays, int maxPlays, int limit = int.MaxValue)
        {
            return this.GetWorldsByPlaysAsync(minPlays, maxPlays, limit).GetResultEx();
        }

        // --- ShopItems ---

        public Task<ShopItem[]> GetShopItemsAsync()
        {
            return this.Client.BigDB.LoadRangeAsync("PayVaultItems", "PriceCoins", null, int.MaxValue, int.MinValue, 1000)
                .Then(task => task.Result.Select(o => new ShopItem(o)).ToArray())
                .ToSafeTask();
        }

        public ShopItem[] GetShopItems()
        {
            return this.GetShopItemsAsync().GetResultEx();
        }

        // --- News ---

        public Task<NewsItem> GetNewsAsync()
        {
            return this.Client.BigDB.LoadSingleAsync("News", "current", true)
                .Then(task => new NewsItem(task.Result))
                .ToSafeTask();
        }

        public NewsItem GetNews()
        {
            return this.GetNewsAsync().GetResultEx();
        }

        // --- Config ---

        // VersionConfiguration

        public Task<VersionConfiguration> GetVersionConfigurationAsync()
        {
            return this.Client.BigDB.LoadAsync("Config", "config")
                .Then(task => new VersionConfiguration(task.Result))
                .ToSafeTask();
        }

        public VersionConfiguration GetVersionConfiguration()
        {
            return this.GetVersionConfigurationAsync().GetResultEx();
        }

        // CampaignConfiguration

        public Task<CampaignConfiguration> GetCampaignConfigurationAsync()
        {
            return this.Client.BigDB.LoadAsync("Config", "campaigns")
                .Then(task => new CampaignConfiguration(task.Result))
                .ToSafeTask();
        }

        public CampaignConfiguration GetCampaignConfiguration()
        {
            return this.GetCampaignConfigurationAsync().GetResultEx();
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
