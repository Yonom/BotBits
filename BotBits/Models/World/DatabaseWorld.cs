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

        public uint BackgroundColor
        {
            get { return this.DatabaseObject.GetUInt("backgroundColor", 0); }
        }

        public int Woots
        {
            get { return this.DatabaseObject.GetInt("woots", 0); }
        }

        public int TotalWoots
        {
            get { return this.DatabaseObject.GetInt("totalwoots", 0); }
        }

        public bool Visible
        {
            get { return this.DatabaseObject.GetBool("visible", true); }
        }

        public bool HideLobby
        {
            get { return this.DatabaseObject.GetBool("hidelobby", false); }
        }

        public bool CoinBanned
        {
            get { return this.DatabaseObject.GetBool("coinbanned", false); }
        }

        public bool WootUpBanned
        {
            get { return this.DatabaseObject.GetBool("wootupbanned", false); }
        }

        public bool IsFeatured
        {
            get { return this.DatabaseObject.GetBool("IsFeatured", false); }
        }

        public bool AllowSpectating
        {
            get { return this.DatabaseObject.GetBool("allowSpectating", true); }
        }

        public string WorldDescription
        {
            get { return this.DatabaseObject.GetString("worldDescription", ""); }
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