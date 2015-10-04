using System;
using System.Linq;
using PlayerIOClient;

namespace BotBits
{
    public class DatabaseWorld : World
    {
        private readonly DatabaseObject _obj;

        public DatabaseObject DatabaseObject
        {
            get { return _obj; }
        }

        public string Name
        {
            get { return this._obj.GetString("name", "Untitled World"); }
        }

        public string Owner
        {
            get { return this._obj.GetString("owner", String.Empty); }
        }

        public WorldType Type
        {
            get
            {
                if (!this._obj.Contains("type"))
                    this._obj.Set("type", (int)WorldUtils.GetLegacyWorldType(this.Width, this.Height));

                return (WorldType)this._obj.GetInt("type");
            }
        }

        public uint BackgroundColor
        {
            get { return this._obj.GetUInt("backgroundColor", 0); }
        }

        public int Woots
        {
            get { return this._obj.GetInt("woots", 0); }
        }

        public int TotalWoots
        {
            get { return this._obj.GetInt("totalwoots", 0); }
        }

        public bool Visible
        {
            get { return this._obj.GetBool("visible", true); }
        }

        public bool HideLobby
        {
            get { return this._obj.GetBool("hidelobby", false); }
        }

        public bool CoinBanned
        {
            get { return this._obj.GetBool("coinbanned", false); }
        }

        public bool WootUpBanned
        {
            get { return this._obj.GetBool("wootupbanned", false); }
        }

        public bool IsFeatured
        {
            get { return this._obj.GetBool("IsFeatured", false); }
        }

        public bool AllowSpectating
        {
            get
            {
                return this._obj.GetBool("allowSpectating", true);
            }
        }

        public String WorldDescription
        {
            get
            {
                return this._obj.GetString("worldDescription", "");
            }
        }


        private DatabaseWorld(DatabaseObject obj, int width, int height)
            : base(width, height)
        {
            this._obj = obj;
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
                var type = (uint)ct.GetValue("type");
                var layerNum = ct.GetInt("layer", 0);
                var xs = ct.GetBytes("x", new byte[0]);
                var ys = ct.GetBytes("y", new byte[0]);
                var x1s = ct.GetBytes("x1", new byte[0]);
                var y1s = ct.GetBytes("y1", new byte[0]);
                var points = WorldUtils.GetShortPos(x1s, y1s)
                  .Concat(WorldUtils.GetPos(xs, ys));

                if (layerNum == 0)
                {
                    var foreground = (Foreground.Id)type;
                    var block = WorldUtils.GetDatabaseBlock(ct, foreground);
                    foreach (var loc in points)
                    {
                        this.Foreground[loc.X, loc.Y] = block;
                    }
                }
                else
                {
                    var background = (Background.Id)type;
                    var block = new BackgroundBlock(background);
                    for (var b = 0; b < xs.Length; b += 2)
                    {
                        var nx = (xs[b] << 8) + xs[b + 1];
                        var ny = (ys[b] << 8) + ys[b + 1];
                        this.Background[nx, ny] = block;
                    }
                }
            }
        }
    }
}