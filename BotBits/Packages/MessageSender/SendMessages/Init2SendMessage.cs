using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Sent to request initialization messages such as add, k, etc.
    /// </summary>
    /// <seealso cref="SendMessage{T}" />
    public sealed class Init2SendMessage : SendMessage<Init2SendMessage>
    {
        internal Init2SendMessage()
        {
        }

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("init2");
        }
    }
}