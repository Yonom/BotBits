using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Sent to collect gold crown.
    /// </summary>
    /// 
    public sealed class CrownSendMessage : SendMessage<CrownSendMessage>
    {
        public CrownSendMessage()
        {
        }

        public CrownSendMessage(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("crown", this.X, this.Y);
        }
    }
}