namespace BotBits
{
    internal class BlockDataWorld
    {
        public BlockDataWorld(int width, int height)
        {
            this.Height = height;
            this.Width = width;
            this.Foreground = new BlockLayer<BlockData<ForegroundBlock>>(width, height);
            this.Background = new BlockLayer<BlockData<BackgroundBlock>>(width, height);
        }

        public BlockLayer<BlockData<BackgroundBlock>> Background { get; private set; }
        public BlockLayer<BlockData<ForegroundBlock>> Foreground { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }
    }
}