using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Class Admin Mode Send Event
    /// </summary>
    public sealed class AdminModeSendMessage : SendMessage<AdminModeSendMessage>
    {
        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("admin");
        }
    }
}