using System;
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

        public int Height { get; }
        public int Width { get; }

        public BlockLayer<TBackground> Background { get; }
        public BlockLayer<TForeground> Foreground { get; }

        IBlockLayer<TBackground> IWorld<TForeground, TBackground>.Background => this.Background;
        IBlockLayer<TForeground> IWorld<TForeground, TBackground>.Foreground => this.Foreground;
        IReadOnlyBlockLayer<TForeground> IReadOnlyWorld<TForeground, TBackground>.Foreground => this.Foreground;
        IReadOnlyBlockLayer<TBackground> IReadOnlyWorld<TForeground, TBackground>.Background => this.Background;

        IWorld<TForeground, TBackground> IWorldAreaEnumerable<TForeground, TBackground>.World => this;
        public Rectangle Area => new Rectangle(0, 0, this.Width, this.Height);

        public IEnumerator<WorldItem<TForeground, TBackground>> GetEnumerator()
        {
            return this.In(this.Area).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}