using System.Diagnostics;

namespace BotBits
{
    [DebuggerDisplay("Id = {Id}")]
    public struct BackgroundBlock
    {
        private readonly Background.Id _id;

        public BackgroundBlock(Background.Id id)
        {
            this._id = id;
        }

        public Background.Id Id
        {
            get { return this._id; }
        }
    }
}