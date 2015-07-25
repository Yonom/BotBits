using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Class Mod Mode Send Event
    /// </summary>
    public sealed class ModModeSendMessage : SendMessage<ModModeSendMessage>
    {
        //No arguments

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("mod");
        }
    }
}