using System;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using PlayerIOClient;

namespace BotBits
{
    public class PlayerObject : DatabaseObjectWrapper
    {
        public PlayerObject(DatabaseObject databaseObject) : base(databaseObject)
        {
        }

        public string UserId => this.DatabaseObject.Key;

        public bool Visible => this.DatabaseObject.GetBool("visible",  true);

        public string Username
        {
            get
            {
                if (this.Guest) throw new NotSupportedException("Guests have no username!");
                return this.DatabaseObject.GetString("name", null);
            }
        }

        public string OldUsername
        {
            get
            {
                if (this.Guest) throw new NotSupportedException("Guests have no username!");
                return this.DatabaseObject.GetString("oldname", null);
            }
        }

        public int Smiley => this.DatabaseObject.GetInt("smiley", 0);

        public bool SmileyGoldBorder => (this.DatabaseObject.GetBool("smileyGoldBorder", false) && this.GoldMember);

        public bool CanChat => !this.DatabaseObject.GetBool("chatbanned", false) && !this.Guest;

        public int Aura => this.DatabaseObject.GetInt("aura", 0);

        public int AuraColor => this.DatabaseObject.GetInt("auraColor", 0);

        public string Badge => this.DatabaseObject.GetString("badge", null);

        public bool GoldMember => this.DatabaseObject.Contains("gold_expire") &&
                                  this.DatabaseObject.GetDateTime("gold_expire") > DateTime.Now;

        public bool OldBetaMember => this.DatabaseObject.GetBool("haveSmileyPackage", false);

        public bool Administrator => this.DatabaseObject.GetBool("isAdministrator", false);
        public bool Moderator => this.DatabaseObject.GetBool("isModerator", false);
        public bool Developer => this.DatabaseObject.GetBool("isDev", false);
        
        public bool Guest => this.DatabaseObject.Key == "simpleguest";


        public DateTime LastLogin => this.DatabaseObject.GetDateTime("lastlogin", default(DateTime));
        public int LoginStreak => this.DatabaseObject.GetInt("loginStreak", 0);

        public bool ConfirmedEmail
        {
            get
            {
                if (this.Guest || !this.DatabaseObject.Key.StartsWith("simple") ||
                    this.DatabaseObject.GetString("name", null) != null)
                {
                    return true;
                }
                return this.DatabaseObject.GetBool("confirmedEmail", false);
            }
        }
        public int TimeZone => this.DatabaseObject.GetInt("timezone", 0);

        public bool PermanentlyBanned => this.DatabaseObject.GetBool("banned", false)
            ;
        public string BanReason => this.DatabaseObject.GetString("ban_reason", null);

        public bool TemporaryBanned => this.DatabaseObject.GetBool("tempbanned", false);

        public int EnergyDelay => this.DatabaseObject.GetInt("energyDelay", 150);

        private DateTime ShopDate => this.DatabaseObject.GetDateTime("shopDate",
            DateTime.Now.AddSeconds(-this.EnergyDelay * this.MaxEnergy));

        public int MaxEnergy
        {
            get
            {
                if (!this.DatabaseObject.Contains("maxEnergy"))
                {
                    this.DatabaseObject.Set("maxEnergy", 200);
                    this.DatabaseObject.Save();
                }

                return this.DatabaseObject.GetInt("maxEnergy");
            }
        }

        public int CurrentEnergy => Math.Min(this.MaxEnergy,
            (int)((DateTime.Now - this.ShopDate).TotalSeconds / this.EnergyDelay));

        public int SecondsToNextEnergy
        {
            get
            {
                var time = (DateTime.Now - this.ShopDate).TotalSeconds / this.EnergyDelay;
                var reminder = time - Math.Floor(time);

                var timeLeftInSecs = (int)(this.EnergyDelay - reminder * this.EnergyDelay);
                return timeLeftInSecs;
            }
        }
        
        public DateTime LastMagic => this.DatabaseObject.GetDateTime("lastcoin", default(DateTime));

        public WorldData GetHomeWorld()
        {
            var homeId = this.DatabaseObject.GetString("worldhome", null);
            if (homeId == null)
                throw new InvalidOperationException("This user does not own a home world.");
            return this.GetWorldDataFromId("worldhome",  homeId);
        }

        public WorldData GetBetaWorld()
        {
            var betaId = this.DatabaseObject.GetString("betaonlyroom");
            if (betaId == null)
                throw new InvalidOperationException("This user does not own a beta world.");
            return this.GetWorldDataFromId("betaonlyroom", betaId);
        }

        public WorldData[] GetWorlds()
        {
            var worlds = this.DatabaseObject.Properties.Where(p => p.StartsWith("world"));
            if (this.DatabaseObject.Contains("betaonlyroom")) worlds = worlds.Concat(new[] { "betaonlyroom" });
            return worlds.Select(w => this.GetWorldDataFromId(w, this.DatabaseObject.GetString(w))).ToArray();
        }

        public string[] GetLikes()
        {
            return this.DatabaseObject.GetObject("likes")?.Where(c => c.Value.Equals(true))
                .Select(c => c.Key)
                .ToArray();
        }

        public string[] GetFavorites()
        {
            return this.DatabaseObject.GetObject("favorites")?.Properties.ToArray() ?? new string[0];
        }


        private WorldData GetWorldDataFromId(string entryId, string worldId)
        {
            bool beta = false;
            WorldType type;
            switch (entryId)
            {
                case "worldhome":
                    type = WorldType.HomeWorld;
                    break;

                case "betaonlyroom":
                    type = WorldType.Massive;
                    beta = true;
                    break;

                default:
                    type = (WorldType)int.Parse(entryId.Substring("world".Length).Split('x')[0]);
                    break;
            }

            var size = WorldUtils.GetWorldSize(type);

            var name = this.DatabaseObject.GetObject("myworldnames")?.GetString(worldId, null);

            return new WorldData(worldId, name, type, size.Width, size.Height, beta);
        }

        public class WorldData
        {
            public WorldData(string id, [CanBeNull] string name, WorldType type, int width, int height, bool beta)
            {
                this.Id = id;
                this.Name = name;
                this.Type = type;
                this.Width = width;
                this.Height = height;
                this.Beta = beta;
            }

            public string Id { get; }
            public string Name { get; }
            public WorldType Type { get; }
            public int Width { get; }
            public int Height { get; }
            public bool Beta { get; }
        }
    }
}