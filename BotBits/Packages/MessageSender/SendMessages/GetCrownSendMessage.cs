using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Class Get Crown Send Event
    /// </summary>
    public sealed class GetCrownSendMessage : RoomTokenSendMessage<GetCrownSendMessage>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public GetCrownSendMessage()
        {
        }

        public GetCrownSendMessage(int x, int y)
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
            return Message.Create(this.RoomToken + "k", this.X, this.Y);
        }
    }
}