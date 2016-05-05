using System.Collections;
using System.Collections.Generic;

namespace BotBits
{
    internal class ReadOnlyBlockLayer<T> : IBlockLayer<T> where T : struct
    {
        private readonly BlockLayer<T> _blockLayer;

        public ReadOnlyBlockLayer(BlockLayer<T> blockLayer)
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
}