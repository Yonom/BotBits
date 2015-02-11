using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BotBits
{
    public struct BlockData<T> where T : struct
    {
        private readonly Player _placer;
        private readonly T _block;

        public BlockData(Player placer, T block)
        {
            _placer = placer;
            _block = block;
        }

        public BlockData(T block)
        {
            _placer = Player.Nobody;
            _block = block;
        }

        public Player Placer
        {
            get
            {
                return this._placer ?? Player.Nobody;
            }
        }

        public T Block
        {
            get { return this._block; }
        }
    }
}
