namespace BotBits
{
    public interface IWorld
    {
        int Height { get; }
        int Width { get; }
        IBlockLayer<ForegroundBlock> Foreground { get; }
        IBlockLayer<BackgroundBlock> Background { get; }
    }
}