using System.Collections.Generic;

namespace BotBits
{
    public interface IReadOnlyBlockLayer<T> : IEnumerable<LayerItem<T>> where T : struct
    {
        int Height { get; }
        int Width { get; }
        T this[int x, int y] { get; }
        T this[Point p] { get; }
    }
}