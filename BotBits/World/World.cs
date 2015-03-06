using System.Diagnostics;

namespace BotBits
{
    [DebuggerDisplay("Width = {Width}, Height = {Height}")]
    public class World : IWorld<ForegroundBlock, BackgroundBlock>
    {
        public World(int width, int height)
        {
            this.Height = height;
            this.Width = width;
            this.Foreground = new BlockLayer<ForegroundBlock>(width, height);
            this.Background = new BlockLayer<BackgroundBlock>(width, height);
        }

        public BlockLayer<BackgroundBlock> Background { get; private set; }
        public BlockLayer<ForegroundBlock> Foreground { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }
    }
}