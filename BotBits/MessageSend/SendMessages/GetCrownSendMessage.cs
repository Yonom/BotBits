using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Class Get Crown Send Event
    /// </summary>
    public sealed class GetCrownSendMessage : RoomTokenSendMessage<GetCrownSendMessage>
    {
        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create(this.RoomToken + "k");
        }
    }
}