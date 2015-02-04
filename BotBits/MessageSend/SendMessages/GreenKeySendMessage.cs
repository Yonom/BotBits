using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Press Green Key Send Event
    /// </summary>
    public sealed class GreenKeySendMessage : RoomTokenSendMessage<GreenKeySendMessage>
    {
        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create(this.RoomToken + "g");
        }
    }
}