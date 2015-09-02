using System.Collections;
using System.Collections.Generic;
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
    public abstract class World<TForeground, TBackground> 
        : IWorld<TForeground, TBackground> , IWorldAreaEnumerable<TForeground, TBackground> 
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
        
        public WorldItem<TForeground, TBackground> At(Point point)
        {
            return this.At(point.X, point.Y);
        }

        public WorldItem<TForeground, TBackground> At(int x, int y)
        {
            return new WorldItem<TForeground, TBackground>(this, x, y);
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

        public IEnumerator<WorldItem<TForeground, TBackground>> GetEnumerator()
        {
            return this.In(this.Area).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        World<TForeground, TBackground> IWorldAreaEnumerable<TForeground, TBackground>.World
        {
            get { return this; }
        }

        public Rectangle Area { get { return new Rectangle(0, 0, this.Width, this.Height); } }
    }
}