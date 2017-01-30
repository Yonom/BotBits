using System.Collections.Generic;

namespace BotBits
{
    public interface IReadOnlyWorldAreaEnumerable<TForeground, TBackground> : IEnumerable<ReadOnlyWorldItem<TForeground, TBackground>>
        where TForeground : struct
        where TBackground : struct
    {
        IReadOnlyWorld<TForeground, TBackground> World { get; }
        Rectangle Area { get; }
    }
}