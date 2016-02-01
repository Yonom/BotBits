using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Sent to toggle administrator mode.
    /// </summary>
    /// <seealso cref="SendMessage{T}" />
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