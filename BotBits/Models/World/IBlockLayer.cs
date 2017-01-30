using System.Collections.Generic;

namespace BotBits
{
    public interface IBlockLayer<T> : IReadOnlyBlockLayer<T> where T : struct
    {
        new T this[int x, int y] { get; set; }
        new T this[Point p] { get; set; }
    }
}