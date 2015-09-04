namespace BotBits
{
    public struct WorldItem<TForeground, TBackground>        
        where TForeground : struct
        where TBackground : struct
    {
        private readonly World<TForeground, TBackground> _world;
        private readonly int _x;
        private readonly int _y;

        public int X
        {
            get { return this._x; }
        }

        public int Y
        {
            get { return this._y; }
        }

        public TForeground Foreground
        {
            get { return this._world.Foreground[this._x, this._y]; }
            set { this._world.Foreground[this._x, this._y] = value; }
        }

        public TBackground Background
        {
            get { return this._world.Background[this._x, this._y]; }
            set { this._world.Background[this._x, this._y] = value; }
        } 

        public WorldItem(World<TForeground, TBackground> world, int x, int y)
        {
            this._world = world;
            this._x = x;
            this._y = y;
        }
    }
}