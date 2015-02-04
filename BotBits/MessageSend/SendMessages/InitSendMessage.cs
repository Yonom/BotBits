using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Class Init Send Event
    /// </summary>
    public sealed class InitSendMessage : SendMessage<InitSendMessage>
    {
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