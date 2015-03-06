using System.Diagnostics;

namespace BotBits
{
    public class World : World<ForegroundBlock, BackgroundBlock>
    {
        public World(int width, int height) 
            : base(width, height)
        {
        }
    }

    [DebuggerDisplay("Width = {Width}, Height = {Height}")]
    public class World<TForeground, TBackground> : IWorld<TForeground, TBackground> 
        where TForeground : struct 
        where TBackground : struct
    {
        public World(int width, int height)
        {
            this.Height = height;
            this.Width = width;
            this.Foreground = new BlockLayer<TForeground>(width, height);
            this.Background = new BlockLayer<TBackground>(width, height);
        }

        public BlockLayer<TBackground> Background { get; private set; }
        public BlockLayer<TForeground> Foreground { get; private set; }

        IBlockLayer<TBackground> IWorld<TForeground, TBackground>.Background
        {
            get { return this.Background; }
        }

        IBlockLayer<TForeground> IWorld<TForeground, TBackground>.Foreground
        {
            get { return this.Foreground; }
        }

        public int Height { get; private set; }
        public int Width { get; private set; }
    }
}