using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Sent to activate green key.
    /// </summary>
    /// <seealso cref="RoomTokenSendMessage{T}" />
    public sealed class GreenKeySendMessage : RoomTokenSendMessage<GreenKeySendMessage>
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
            return Message.Create(this.RoomToken + "g", this.X, this.Y);
        }
    }
}