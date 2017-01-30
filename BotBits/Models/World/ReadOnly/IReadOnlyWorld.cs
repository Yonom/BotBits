using System.Collections.Generic;

namespace BotBits
{
    public interface IReadOnlyWorld<TForeground, TBackground>
        where TForeground : struct
        where TBackground : struct
    {
        int Width { get; }
        int Height { get; }

        IReadOnlyBlockLayer<TForeground> Foreground { get; }
        IReadOnlyBlockLayer<TBackground> Background { get; }
    }
}