using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Sent to kill world.
    /// </summary>
    /// <seealso cref="SendMessage{T}" />
    public sealed class KillRoomSendMessage : SendMessage<KillRoomSendMessage>
    {
        //No arguments

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("kill");
        }
    }
}