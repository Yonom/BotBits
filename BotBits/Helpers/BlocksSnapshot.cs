using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BotBits
{
    public class BlocksSnapshot : IWorld<ForegroundBlock, BackgroundBlock>, IWorldAreaEnumerable<ForegroundBlock, BackgroundBlock>
    {
        private readonly Blocks _parent;

        public BlocksSnapshot(Blocks parent)
        {
            this._parent = parent;
            this.Background = new SnapshotBlockLayer<BackgroundBlock>(parent.Background);
            this.Foreground = new SnapshotBlockLayer<ForegroundBlock>(parent.Foreground);
        }

        public int Width => this._parent.Width;
        public int Height => this._parent.Height;

        public SnapshotBlockLayer<BackgroundBlock> Background { get; }
        public SnapshotBlockLayer<ForegroundBlock> Foreground { get; }

        IBlockLayer<BackgroundBlock> IWorld<ForegroundBlock, BackgroundBlock>.Background => this.Background;
        IBlockLayer<ForegroundBlock> IWorld<ForegroundBlock, BackgroundBlock>.Foreground => this.Foreground;
        IReadOnlyBlockLayer<BackgroundBlock> IReadOnlyWorld<ForegroundBlock, BackgroundBlock>.Background => this.Background;
        IReadOnlyBlockLayer<ForegroundBlock> IReadOnlyWorld<ForegroundBlock, BackgroundBlock>.Foreground => this.Foreground;

        public IEnumerator<WorldItem<ForegroundBlock, BackgroundBlock>> GetEnumerator()
        {
            return this.In(this.Area).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IWorld<ForegroundBlock, BackgroundBlock> World => this;
        public Rectangle Area => new Rectangle(0, 0, this.Width, this.Height);

        public void Sync()
        {
            foreach (var fg in this.Foreground.Changes)
            {
                this._parent.Place(fg.Key.X, fg.Key.Y, fg.Value);
            }
            this.Foreground.Changes.Clear();

            foreach (var bg in this.Background.Changes)
            {
                this._parent.Place(bg.Key.X, bg.Key.Y, bg.Value);
            }
            this.Background.Changes.Clear();
        }
    }

    public class SnapshotBlockLayer<T> : IBlockLayer<T> where T : struct
    {
        private readonly IReadOnlyBlockLayer<BlockData<T>> _innerLayer;

        public Dictionary<Point, T> Changes { get; } = new Dictionary<Point, T>();

        public SnapshotBlockLayer(IReadOnlyBlockLayer<BlockData<T>> innerLayer)
        {
            this._innerLayer = innerLayer;
        }

        public int Height => this._innerLayer.Height;
        public int Width => this._innerLayer.Width;

        public T this[int x, int y]
        {
            get { return this[new Point(x, y)]; }
            set { this[new Point(x, y)] = value; }
        }

        public T this[Point p]
        {
            get
            {
                T res;
                if (!this.Changes.TryGetValue(p, out res))
                    res = this._innerLayer[p].Block;
                return res;
            }
            set { this.Changes[p] = value; }
        }
        
        public IEnumerator<LayerItem<T>> GetEnumerator()
        {
            return this._innerLayer
                .Select(item =>
                {
                    T res;
                    if (!this.Changes.TryGetValue(new Point(item.X, item.Y), out res))
                        res = item.Data.Block;
                    return new LayerItem<T>(res, item.X, item.Y);
                })
                .GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}