using System.Diagnostics;

namespace BotBits
{
    [DebuggerDisplay("Id = {Id}")]
    public struct BackgroundBlock
    {
        private readonly Background _id;

        public BackgroundBlock(Background id)
        {
            this._id = id;
        }

        public Background Id
        {
            get { return this._id; }
        }
    }
}