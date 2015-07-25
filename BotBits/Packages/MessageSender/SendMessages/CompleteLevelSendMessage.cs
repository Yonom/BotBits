using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Class Complete Level Send Event
    /// </summary>
    public sealed class CompleteLevelSendMessage : SendMessage<CompleteLevelSendMessage>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public CompleteLevelSendMessage()
        {
        }

        public CompleteLevelSendMessage(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("levelcomplete", this.X, this.Y);
        }
    }
}