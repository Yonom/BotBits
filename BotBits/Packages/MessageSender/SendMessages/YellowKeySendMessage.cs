using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Class Press Red Key Send Event
    /// </summary>
    public sealed class YellowKeySendMessage : RoomTokenSendMessage<YellowKeySendMessage>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public YellowKeySendMessage()
        {
        }

        public YellowKeySendMessage(int x, int y)
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
            return Message.Create(this.RoomToken + "y", this.X, this.Y);
        }
    }
}