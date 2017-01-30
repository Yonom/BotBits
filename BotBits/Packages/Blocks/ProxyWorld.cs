using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BotBits
{
    public class ProxyWorld : IReadOnlyWorld<ForegroundBlock, BackgroundBlock>, IReadOnlyWorldAreaEnumerable<ForegroundBlock, BackgroundBlock>
    {
        private readonly Blocks _innerWorld;

        internal ProxyWorld(Blocks innerWorld)
        {
            this._innerWorld = innerWorld;
        }

        public int Width => this._innerWorld.Width;
        public int Height => this._innerWorld.Height;

        public IReadOnlyBlockLayer<ForegroundBlock> Foreground => new ProxyLayer<ForegroundBlock>(this._innerWorld.Foreground);
        public IReadOnlyBlockLayer<BackgroundBlock> Background => new ProxyLayer<BackgroundBlock>(this._innerWorld.Background);

        private class ProxyLayer<T> : IReadOnlyBlockLayer<T> where T : struct
        {
            private readonly IReadOnlyBlockLayer<BlockData<T>> _innerLayer;

            public ProxyLayer(IReadOnlyBlockLayer<BlockData<T>> innerLayer)
            {
                this._innerLayer = innerLayer;
            }

            public T this[Point p] => this._innerLayer[p].Block;

            public T this[int x, int y] => this._innerLayer[x, y].Block;

            public int Height => this._innerLayer.Height;

            public int Width => this._innerLayer.Width;

            public IEnumerator<LayerItem<T>> GetEnumerator()
            {
                return this._innerLayer
                    .Select(item => new LayerItem<T>(item.Data.Block, item.X, item.Y))
                    .GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
        }

        public IEnumerator<ReadOnlyWorldItem<ForegroundBlock, BackgroundBlock>> GetEnumerator()
        {
            return this.In(this.Area).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        IReadOnlyWorld<ForegroundBlock, BackgroundBlock> IReadOnlyWorldAreaEnumerable<ForegroundBlock, BackgroundBlock>.World => this;
        public Rectangle Area => new Rectangle(0, 0, this.Width, this.Height);
    }
}