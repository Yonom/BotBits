using PlayerIOClient;

namespace BotBits.SendMessages
{
    public sealed class UnfavoriteSendMessage : SendMessage<UnfavoriteSendMessage>
    {
        //No arguments

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("unfavorite");
        }
    }
}