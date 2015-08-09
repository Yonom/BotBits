using System.Collections;
using System.Collections.Generic;

namespace BotBits
{
    public class BlockAreaEnumerable : IBlockAreaEnumerable
    {
        public Blocks Blocks { get; private set; }
        public Rectangle Area { get; private set; }

        public BlockAreaEnumerable(Blocks blocks, Rectangle area)
        {
            this.Blocks = blocks;
            this.Area = area;
        }

        public IEnumerator<BlocksItem> GetEnumerator()
        {
            for (int y = this.Area.Top; y <= this.Area.Bottom; y++)
                for (int x = this.Area.Left; x <= this.Area.Right; x++)
                    yield return new BlocksItem(
                        this.Blocks, x, y);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
