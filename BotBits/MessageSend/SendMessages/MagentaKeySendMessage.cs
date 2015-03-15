using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Class Press Red Key Send Event
    /// </summary>
    public sealed class MagentaKeySendMessage : RoomTokenSendMessage<MagentaKeySendMessage>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public MagentaKeySendMessage()
        {
        }

        public MagentaKeySendMessage(int x, int y)
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
            return Message.Create(this.RoomToken + "m", this.X, this.Y);
        }
    }
}