using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Class Press Red Key Send Event
    /// </summary>
    public sealed class CyanKeySendMessage : RoomTokenSendMessage<CyanKeySendMessage>
    {
        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create(this.RoomToken + "c");
        }
    }
}