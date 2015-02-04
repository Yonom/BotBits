using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Class Save World Send Event
    /// </summary>
    public sealed class SaveSendMessage : SendMessage<SaveSendMessage>
    {
        //No arguments

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("save");
        }
    }
}