using System;
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

        public string Id => this.DatabaseObject.Key;

        public string Name => this.DatabaseObject.GetString("name", "Untitled World");

        public string Owner => this.DatabaseObject.GetString("owner", string.Empty);

        public WorldType Type
        {
            get
            {
                if (!this.DatabaseObject.Contains("type")) this.DatabaseObject.Set("type", (int)WorldUtils.GetLegacyWorldType(this.Width, this.Height));

                return (WorldType)this.DatabaseObject.GetInt("type");
            }
        }

        public int Plays => this.DatabaseObject.GetInt("plays", 0);

        public int CurseLimit => this.DatabaseObject.GetInt("curseLimit", 0);

        public int ZombieLimit => this.DatabaseObject.GetInt("zombieLimit", 0);

        public uint BackgroundColor => this.DatabaseObject.GetUInt("backgroundColor", 0);

        public Foreground.Id BorderType => (Foreground.Id)this.DatabaseObject.GetUInt("BorderType", this.Type == WorldType.MoonLarge ? 182u : 9u);

        public int Favorites => this.DatabaseObject.GetInt("Favorites", 0);

        public int Likes => this.DatabaseObject.GetInt("Likes", 0);

        public bool Visible => this.DatabaseObject.GetBool("visible", true);

        public bool HideLobby => this.DatabaseObject.GetBool("hidelobby", false);

        public bool IsFeatured => this.DatabaseObject.GetBool("IsFeatured", false);

        public bool MinimapEnabled => this.DatabaseObject.GetBool("MinimapEnabled", false);

        public bool LobbyPreviewEnabled => this.DatabaseObject.GetBool("LobbyPreviewEnabled", false);

        public double GravityMultiplier => this.DatabaseObject.GetDouble("Gravity", this.Type == WorldType.MoonLarge ? 0.16 : 1);

        public bool AllowSpectating => this.DatabaseObject.GetBool("allowSpectating", true);

        public string WorldDescription => this.DatabaseObject.GetString("worldDescription", "");

        public string Campaign => this.DatabaseObject.GetString("Campaign", "");

        public bool IsPartOfCampaign => this.Campaign != "";

        public string Crew => this.DatabaseObject.GetString("Crew", "");

        public bool IsPartOfCrew => this.Crew != "";

        public bool IsCrewLogo => this.DatabaseObject.GetBool("IsCrewLogo", false);

        public WorldStatus WorldStatus => this.IsPartOfCrew
            ? (WorldStatus)this.DatabaseObject.GetInt("Status", 1)
            : WorldStatus.NonCrew;

        public bool CrewVisibleInLobby => !this.IsCrewLogo && this.WorldStatus != WorldStatus.WIP;

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

                try
                {
                    var type = Convert.ToUInt32(ct.GetValue("type"));
                    var layerNum = ct.GetInt("layer", 0);
                    var xArr = ct.GetBytes("x", new byte[0]);
                    var yArr = ct.GetBytes("y", new byte[0]);
                    var x1Arr = ct.GetBytes("x1", new byte[0]);
                    var y1Arr = ct.GetBytes("y1", new byte[0]);
                    var points = WorldUtils.GetShortPos(x1Arr, y1Arr)
                        .Concat(WorldUtils.GetPos(xArr, yArr));

                    if (layerNum == 0)
                    {
                        var foreground = (Foreground.Id)type;
                        var block = WorldUtils.GetForegroundFromDatabase(ct, foreground);
                        foreach (var loc in points)
                        {
                            this.Foreground[loc.X, loc.Y] = block;
                        }
                    }
                    else
                    {
                        var background = (Background.Id)type;
                        var block = new BackgroundBlock(background);
                        foreach (var loc in points)
                        {
                            this.Background[loc.X, loc.Y] = block;
                        }
                    }
                }
                catch (Exception)
                {
                    
                }
            }
        }
    }
}