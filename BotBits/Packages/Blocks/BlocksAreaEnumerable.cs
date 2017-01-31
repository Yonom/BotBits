using System.Collections;
using System.Collections.Generic;

namespace BotBits
{
    public class BlocksAreaEnumerable : IBlockAreaEnumerable
    {
        public BlocksAreaEnumerable(Blocks blocks, Rectangle area)
        {
            this.Blocks = blocks;
            this.Area = area;
        }

        public Blocks Blocks { get; }
        public Rectangle Area { get; }

        public IEnumerator<BlocksItem> GetEnumerator()
        {
            for (var y = this.Area.Top; y <= this.Area.Bottom; y++)
                for (var x = this.Area.Left; x <= this.Area.Right; x++)
                    yield return new BlocksItem(
                        this.Blocks, x, y);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}