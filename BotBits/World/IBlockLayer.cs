using System.Collections.Generic;

namespace BotBits
{
    public interface IBlockLayer<T> : IEnumerable<KeyValuePair<Point, T>> where T : struct
    {
        int Height { get; }
        int Width { get; }
        T this[int x, int y] { get; }
    }
}