using System.Collections;
using System.Collections.Generic;

namespace BotBits
{
    public class BlocksEnumerable : IEnumerable<BlocksItem>
    {
        private readonly Blocks _parent;
        private readonly Rectangle _area;

        public BlocksEnumerable(Blocks parent, Rectangle area)
        {
            this._parent = parent;
            this._area = area;
            
        }

        public BlocksEnumerable In(Rectangle area)
        {
            return new BlocksEnumerable(this._parent, Rectangle.Intersect(area, this._area));
        }

        public IEnumerator<BlocksItem> GetEnumerator()
        {
            for (int y = _area.Top; y < _area.Bottom; y++)
                for (int x = _area.Left; x < _area.Right; x++)
                    yield return new BlocksItem(
                        this._parent, x, y);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
