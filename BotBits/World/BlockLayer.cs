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

        public int Width { get; private set; }
        public int Height { get; private set; }

        public T this[int x, int y]
        {
            get { return this._blocks[x, y]; }
            set { this._blocks[x, y] = value; }
        }

        public IEnumerator<KeyValuePair<Point, T>> GetEnumerator()
        {
            for (int y = 0; y < this.Height; y++)
                for (int x = 0; x < this.Width; x++)
                    yield return new KeyValuePair<Point, T>(
                        new Point(x, y), this._blocks[x, y]);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}