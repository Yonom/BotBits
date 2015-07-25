using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Class Death Send Event
    /// </summary>
    public sealed class DeathSendMessage : SendMessage<DeathSendMessage>
    {
        //No arguments

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("death");
        }
    }
}