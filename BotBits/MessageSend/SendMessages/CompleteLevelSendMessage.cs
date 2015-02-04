using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Class Complete Level Send Event
    /// </summary>
    public sealed class CompleteLevelSendMessage : SendMessage<CompleteLevelSendMessage>
    {
        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("levelcomplete");
        }
    }
}