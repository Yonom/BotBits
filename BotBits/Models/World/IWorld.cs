using System.Collections.Generic;

namespace BotBits
{
    public interface IWorld<TForeground, TBackground> 
        : IReadOnlyWorld<TForeground, TBackground>
        where TForeground : struct 
        where TBackground : struct
    {
        new IBlockLayer<TForeground> Foreground { get; }
        new IBlockLayer<TBackground> Background { get; }
    }
}