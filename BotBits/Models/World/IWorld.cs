using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BotBits
{
    public interface IWorld : IWorld<ForegroundBlock, BackgroundBlock>
    {
        
    }

    public interface IWorld<TForeground, TBackground> where TForeground : struct where TBackground : struct
    {
        int Width { get; }
        int Height { get; }

        IBlockLayer<TForeground> Foreground { get; }
        IBlockLayer<TBackground> Background { get; }
    }
}
