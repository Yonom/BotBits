using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Class Press Red Key Send Event
    /// </summary>
    public sealed class CyanKeySendMessage : RoomTokenSendMessage<CyanKeySendMessage>
    {
        public CyanKeySendMessage()
        {
        }

        public CyanKeySendMessage(int x, int y)
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
            return Message.Create(this.RoomToken + "c", this.X, this.Y);
        }
    }
}