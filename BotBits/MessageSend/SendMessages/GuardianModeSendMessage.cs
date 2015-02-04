using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Class GuardianMode Send Event
    /// </summary>
    public sealed class GuardianModeSendMessage : SendMessage<GuardianModeSendMessage>
    {
        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("guardian");
        }
    }
}