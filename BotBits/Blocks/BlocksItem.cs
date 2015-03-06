using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BotBits
{
    public struct BlocksItem
    {
        private readonly Blocks _blocks;
        private readonly int _x;
        private readonly int _y;

        public int X
        {
            get { return this._x; }
        }

        public int Y
        {
            get { return this._y; }
        }

        public BlockData<ForegroundBlock> Foreground
        {
            get { return _blocks.Foreground[this._x, this._y]; }
        }

        public BlockData<BackgroundBlock> Background
        {
            get { return _blocks.Background[this._x, this._y]; }
        } 

        internal BlocksItem(Blocks blocks, int x, int y)
        {
            this._blocks = blocks;
            this._x = x;
            this._y = y;
        }

        public void Set(ForegroundBlock block)
        {
            this._blocks.Place(this._x, this._y, block);
        }

        public void Set(BackgroundBlock block)
        {
            this._blocks.Place(this._x, this._y, block);
        }
    }
}
