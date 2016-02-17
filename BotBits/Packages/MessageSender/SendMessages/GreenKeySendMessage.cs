using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Sent to activate green key.
    /// </summary>
    /// 
    public sealed class GreenKeySendMessage : SendMessage<GreenKeySendMessage>
    {
        public GreenKeySendMessage()
        {
        }

        public GreenKeySendMessage(int x, int y)
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
            return Message.Create("pressKey", this.X, this.Y, "green");
        }
    }
}