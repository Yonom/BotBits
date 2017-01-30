namespace BotBits
{
    public struct WorldItem<TForeground, TBackground>
        where TForeground : struct
        where TBackground : struct
    {
        private readonly IWorld<TForeground, TBackground> _world;

        public int X { get; }
        public int Y { get; }

        public TForeground Foreground
        {
            get { return this._world.Foreground[this.X, this.Y]; }
            set { this._world.Foreground[this.X, this.Y] = value; }
        }

        public TBackground Background
        {
            get { return this._world.Background[this.X, this.Y]; }
            set { this._world.Background[this.X, this.Y] = value; }
        }

        public WorldItem(IWorld<TForeground, TBackground> world, int x, int y)
        {
            this._world = world;
            this.X = x;
            this.Y = y;
        }
    }
}