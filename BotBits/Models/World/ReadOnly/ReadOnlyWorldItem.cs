namespace BotBits
{
    public struct ReadOnlyWorldItem<TForeground, TBackground>
        where TForeground : struct
        where TBackground : struct
    {
        private readonly IReadOnlyWorld<TForeground, TBackground> _world;

        public int X { get; }
        public int Y { get; }

        public TForeground Foreground => this._world.Foreground[this.X, this.Y];
        public TBackground Background => this._world.Background[this.X, this.Y];

        public ReadOnlyWorldItem(IReadOnlyWorld<TForeground, TBackground> world, int x, int y)
        {
            this._world = world;
            this.X = x;
            this.Y = y;
        }
    }
}