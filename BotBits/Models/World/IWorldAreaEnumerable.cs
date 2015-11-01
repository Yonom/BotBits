using System.Collections.Generic;

namespace BotBits
{
    public interface IWorldAreaEnumerable<TForeground, TBackground> : IEnumerable<WorldItem<TForeground, TBackground>>
        where TForeground : struct
        where TBackground : struct
    {
        World<TForeground, TBackground> World { get; }
        Rectangle Area { get; }
    }
}