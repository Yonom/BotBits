namespace BotBits
{
    internal class ReadOnlyBlocksWorld : IWorld<BlockData<ForegroundBlock>, BlockData<BackgroundBlock>>
    {
        public ReadOnlyBlocksWorld(BlockDataWorld world)
        {
            this.Height = world.Height;
            this.Width = world.Width;
            this.Foreground = new ReadOnlyBlockLayer<BlockData<ForegroundBlock>>(world.Foreground);
            this.Background = new ReadOnlyBlockLayer<BlockData<BackgroundBlock>>(world.Background);
        }

        public IBlockLayer<BlockData<BackgroundBlock>> Background { get; }
        public IBlockLayer<BlockData<ForegroundBlock>> Foreground { get; }
        public int Height { get; }
        public int Width { get; }
    }
}