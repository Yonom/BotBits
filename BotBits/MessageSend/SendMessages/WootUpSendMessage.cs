using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Class Woot Up Send Event
    /// </summary>
    public sealed class WootUpSendMessage : SendMessage<WootUpSendMessage>
    {
        //No arguments

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("wootup");
        }
    }
}