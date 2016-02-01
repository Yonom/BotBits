using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Sent to add world to crew.
    /// </summary>
    /// <seealso cref="SendMessage{T}" />
    public sealed class AddToCrewSendMessage : SendMessage<AddToCrewSendMessage>
    {
        //No arguments

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("addToCrew");
        }
    }
}