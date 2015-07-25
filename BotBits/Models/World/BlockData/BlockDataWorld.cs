namespace BotBits
{
    internal class BlockDataWorld : World<BlockData<ForegroundBlock>, BlockData<BackgroundBlock>>
    {
        public BlockDataWorld(int width, int height)
            : base(width, height)
        {
        }
    }
}