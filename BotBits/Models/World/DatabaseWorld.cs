using System.Linq;
using PlayerIOClient;

namespace BotBits
{
    public class DatabaseWorld : World
    {
        private DatabaseWorld(DatabaseObject obj, int width, int height)
            : base(width, height)
        {
            this.DatabaseObject = obj;
        }

        public DatabaseObject DatabaseObject { get; }

        public string Id
        {
            get { return this.DatabaseObject.Key; }
        }

        public string Name
        {
            get { return this.DatabaseObject.GetString("name", "Untitled World"); }
        }

        public string Owner
        {
            get { return this.DatabaseObject.GetString("owner", string.Empty); }
        }

        public WorldType Type
        {
            get
            {
                if (!this.DatabaseObject.Contains("type"))
                    this.DatabaseObject.Set("type", (int) WorldUtils.GetLegacyWorldType(this.Width, this.Height));

                return (WorldType) this.DatabaseObject.GetInt("type");
            }
        }

        public int Plays
        {
            get { return this.DatabaseObject.GetInt("plays", 0); }
        }

        public int CurseLimit
        {
            get { return this.DatabaseObject.GetInt("curseLimit", 0); }
        }

        public int ZombieLimit
        {
            get { return this.DatabaseObject.GetInt("zombieLimit", 0); }
        }

        public uint BackgroundColor
        {
            get { return this.DatabaseObject.GetUInt("backgroundColor", 0); }
        }

        public Foreground.Id BorderType
        {
            get { return (Foreground.Id)this.DatabaseObject.GetUInt("BorderType", this.Type == WorldType.MoonLarge ? 182u : 9u); }
        }

        public int Favorites
        {
            get { return this.DatabaseObject.GetInt("Favorites", 0); }
        }

        public int Likes
        {
            get { return this.DatabaseObject.GetInt("Likes", 0); }
        }

        public bool Visible
        {
            get { return this.DatabaseObject.GetBool("visible", true); }
        }

        public bool HideLobby
        {
            get { return this.DatabaseObject.GetBool("hidelobby", false); }
        }

        public bool IsFeatured
        {
            get { return this.DatabaseObject.GetBool("IsFeatured", false); }
        }

        public bool MinimapEnabled
        {
            get { return this.DatabaseObject.GetBool("MinimapEnabled", false); }
        }

        public bool LobbyPreviewEnabled
        {
            get { return this.DatabaseObject.GetBool("LobbyPreviewEnabled", false); }
        }

        public double GravityMultiplier
        {
            get { return this.DatabaseObject.GetDouble("Gravity", this.Type == WorldType.MoonLarge ? 0.16 : 1); }
        }

        public bool AllowSpectating
        {
            get { return this.DatabaseObject.GetBool("allowSpectating", true); }
        }

        public string WorldDescription
        {
            get { return this.DatabaseObject.GetString("worldDescription", ""); }
        }

        public string Campaign
        {
            get { return this.DatabaseObject.GetString("Campaign", ""); }
        }

        public bool IsPartOfCampaign
        {
            get { return this.Campaign != ""; }
        }

        public string Crew
        {
            get { return this.DatabaseObject.GetString("Crew", ""); }
        }

        public bool IsPartOfCrew
        {
            get { return this.Crew != ""; }
        }

        public bool IsCrewLogo
        {
            get { return this.DatabaseObject.GetBool("IsCrewLogo", false); ; }
        }

        public WorldStatus WorldStatus
        {
            get
            {
                return this.IsPartOfCrew
                    ? (WorldStatus)this.DatabaseObject.GetInt("Status", 1)
                    : WorldStatus.NonCrew;
            }
        }

        public bool CrewVisibleInLobby
        {
            get { return !this.IsCrewLogo && this.WorldStatus != WorldStatus.WIP; }
        }

        public static DatabaseWorld FromDatabaseObject(DatabaseObject obj)
        {
            var width = obj.GetInt("width", 200);
            var height = obj.GetInt("height", 200);
            var world = new DatabaseWorld(obj, width, height);
            var worldData = obj.GetArray("worlddata");
            if (worldData != null)
            {
                world.UnserializeFromComplexObject(worldData);
            }

            return world;
        }

        private void UnserializeFromComplexObject(DatabaseArray worlddata)
        {
            foreach (DatabaseObject ct in worlddata)
            {
                if (ct.Count == 0) continue;
                var type = (uint) ct.GetValue("type");
                var layerNum = ct.GetInt("layer", 0);
                var xs = ct.GetBytes("x", new byte[0]);
                var ys = ct.GetBytes("y", new byte[0]);
                var x1s = ct.GetBytes("x1", new byte[0]);
                var y1s = ct.GetBytes("y1", new byte[0]);
                var points = WorldUtils.GetShortPos(x1s, y1s)
                    .Concat(WorldUtils.GetPos(xs, ys));

                if (layerNum == 0)
                {
                    var foreground = (Foreground.Id) type;
                    var block = WorldUtils.GetDatabaseBlock(ct, foreground);
                    foreach (var loc in points)
                    {
                        this.Foreground[loc.X, loc.Y] = block;
                    }
                }
                else
                {
                    var background = (Background.Id) type;
                    var block = new BackgroundBlock(background);
                    foreach (var loc in points)
                    {
                        this.Background[loc.X, loc.Y] = block;
                    }
                }
            }
        }
    }
}