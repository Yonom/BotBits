using System;
using System.Collections;
using System.Collections.Generic;

namespace BotBits
{
    internal class ReadOnlyBlocksWorld : IReadOnlyWorld<BlockData<ForegroundBlock>, BlockData<BackgroundBlock>>, IReadOnlyWorldAreaEnumerable<BlockData<ForegroundBlock>, BlockData<BackgroundBlock>>
    {
        public ReadOnlyBlocksWorld(BlockDataWorld world)
        {
            this.Height = world.Height;
            this.Width = world.Width;
            this.Foreground = new ReadOnlyBlocksBlockLayer<BlockData<ForegroundBlock>>(world.Foreground);
            this.Background = new ReadOnlyBlocksBlockLayer<BlockData<BackgroundBlock>>(world.Background);
        }

        public IReadOnlyBlockLayer<BlockData<BackgroundBlock>> Background { get; }
        public IReadOnlyBlockLayer<BlockData<ForegroundBlock>> Foreground { get; }
        public int Height { get; }
        public int Width { get; }


        private class ReadOnlyBlocksBlockLayer<T> : IReadOnlyBlockLayer<T> where T : struct
        {
            private readonly BlockLayer<T> _blockLayer;

            public ReadOnlyBlocksBlockLayer(BlockLayer<T> blockLayer)
            {
                this._blockLayer = blockLayer;
            }

            public int Height => this._blockLayer.Height;

            public int Width => this._blockLayer.Width;

            public T this[int x, int y] => this._blockLayer[x, y];

            public T this[Point p] => this._blockLayer[p.X, p.Y];

            public IEnumerator<LayerItem<T>> GetEnumerator()
            {
                return this._blockLayer.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }

        public IEnumerator<ReadOnlyWorldItem<BlockData<ForegroundBlock>, BlockData<BackgroundBlock>>> GetEnumerator()
        {
            return this.In(this.Area).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        IReadOnlyWorld<BlockData<ForegroundBlock>, BlockData<BackgroundBlock>> IReadOnlyWorldAreaEnumerable<BlockData<ForegroundBlock>, BlockData<BackgroundBlock>>.World => this;
        public Rectangle Area => new Rectangle(0, 0, this.Width, this.Height);
    }
}