using System.Collections;
using System.Collections.Generic;

namespace BotBits
{
    public class BlockLayer<T> : IBlockLayer<T> where T : struct
    {
        private readonly T[,] _blocks;

        internal BlockLayer(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            this._blocks = new T[width, height];
        }

        public int Width { get; }
        public int Height { get; }

        public T this[int x, int y]
        {
            get { return this._blocks[x, y]; }
            set { this._blocks[x, y] = value; }
        }

        public T this[Point p]
        {
            get { return this[p.X, p.Y]; }
            set { this[p.X, p.Y] = value; }
        }

        public IEnumerator<LayerItem<T>> GetEnumerator()
        {
            for (var y = 0; y < this.Height; y++)
                for (var x = 0; x < this.Width; x++)
                    yield return new LayerItem<T>(
                        new Point(x, y), this._blocks[x, y]);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}