using System.Collections.Generic;

namespace BotBits
{
    public interface IBlockAreaEnumerable : IEnumerable<BlocksItem>
    {
        Blocks Blocks { get; }
        Rectangle Area { get; }
    }
}