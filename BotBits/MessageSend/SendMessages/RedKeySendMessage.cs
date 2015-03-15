using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Class Press Red Key Send Event
    /// </summary>
    public sealed class RedKeySendMessage : RoomTokenSendMessage<RedKeySendMessage>
    {        
        public int X { get; set; }
        public int Y { get; set; }

        public RedKeySendMessage()
        {
        }

        public RedKeySendMessage(int x, int y)
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
            return Message.Create(this.RoomToken + "r", this.X, this.Y);
        }
    }
}