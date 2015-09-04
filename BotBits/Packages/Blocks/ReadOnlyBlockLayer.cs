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

        public int Height
        {
            get { return this._blockLayer.Height; }
        }

        public int Width
        {
            get { return this._blockLayer.Width; }
        }

        public T this[int x, int y]
        {
            get { return this._blockLayer[x, y]; }
        }

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