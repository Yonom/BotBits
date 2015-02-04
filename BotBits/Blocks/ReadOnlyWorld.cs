namespace BotBits
{
    internal class ReadOnlyWorld : IWorld
    {
        private readonly World _world;

        public ReadOnlyWorld(World world)
        {
            this._world = world;
        }

        public int Height
        {
            get { return this._world.Height; }
        }

        public int Width
        {
            get { return this._world.Width; }
        }

        public IBlockLayer<BackgroundBlock> Background
        {
            get { return this._world.Background; }
        }

        public IBlockLayer<ForegroundBlock> Foreground
        {
            get { return this._world.Foreground; }
        }
    }
}