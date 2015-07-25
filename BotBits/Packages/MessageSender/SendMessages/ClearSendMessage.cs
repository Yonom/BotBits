using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Class Clear World Send Event
    /// </summary>
    public sealed class ClearSendMessage : SendMessage<ClearSendMessage>
    {
        //No arguments

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("clear");
        }
    }
}