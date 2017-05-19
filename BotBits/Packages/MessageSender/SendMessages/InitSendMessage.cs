using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Sent to request initialization message.
    /// </summary>
    /// <seealso cref="SendMessage{T}" />
    public sealed class InitSendMessage : SendMessage<InitSendMessage>
    {
        internal InitSendMessage()
        {
        }

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("init");
        }
    }
}