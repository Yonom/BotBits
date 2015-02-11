namespace BotBits
{
    internal class ReadOnlyBlocksWorld
    {
        public ReadOnlyBlocksWorld(BlocksWorld world)
        {
            this.Height = world.Height;
            this.Width = world.Width;
            this.Foreground = new ReadOnlyBlockLayer<BlockData<ForegroundBlock>>(world.Foreground); 
            this.Background = new ReadOnlyBlockLayer<BlockData<BackgroundBlock>>(world.Background);
        }

        public ReadOnlyBlockLayer<BlockData<BackgroundBlock>> Background { get; private set; }
        public ReadOnlyBlockLayer<BlockData<ForegroundBlock>> Foreground { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }
    }
}