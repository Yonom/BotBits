using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Class Init2 Send Event
    /// </summary>
    public sealed class Init2SendMessage : SendMessage<Init2SendMessage>
    {
        //No arguments

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