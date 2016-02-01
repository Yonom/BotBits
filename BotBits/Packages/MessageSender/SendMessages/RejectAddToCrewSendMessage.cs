using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Sent to reject add to crew request.
    /// </summary>
    /// <seealso cref="SendMessage{T}" />
    public sealed class RejectAddToCrewSendMessage : SendMessage<RejectAddToCrewSendMessage>
    {
        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("rejectAddToCrew");
        }
    }
}