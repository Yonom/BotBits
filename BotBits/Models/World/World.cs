using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace BotBits
{
    public class World : World<ForegroundBlock, BackgroundBlock>, IWorld
    {
        public World(int width, int height)
            : base(width, height)
        {
        }
    }

    [DebuggerDisplay("Width = {Width}, Height = {Height}")]
    public abstract class World<TForeground, TBackground>
        : IWorld<TForeground, TBackground>, IWorldAreaEnumerable<TForeground, TBackground>
        where TForeground : struct
        where TBackground : struct
    {
        protected World(int width, int height)
        {
            this.Height = height;
            this.Width = width;
            this.Foreground = new BlockLayer<TForeground>(width, height);
            this.Background = new BlockLayer<TBackground>(width, height);
        }

        public BlockLayer<TBackground> Background { get; }
        public BlockLayer<TForeground> Foreground { get; }

        IBlockLayer<TBackground> IWorld<TForeground, TBackground>.Background => this.Background;

        IBlockLayer<TForeground> IWorld<TForeground, TBackground>.Foreground => this.Foreground;

        public int Height { get; }
        public int Width { get; }

        public IEnumerator<WorldItem<TForeground, TBackground>> GetEnumerator()
        {
            return this.In(this.Area).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        World<TForeground, TBackground> IWorldAreaEnumerable<TForeground, TBackground>.World => this;

        public Rectangle Area => new Rectangle(0, 0, this.Width, this.Height);

        public WorldItem<TForeground, TBackground> At(Point point)
        {
            return this.At(point.X, point.Y);
        }

        public WorldItem<TForeground, TBackground> At(int x, int y)
        {
            return new WorldItem<TForeground, TBackground>(this, x, y);
        }
    }
}