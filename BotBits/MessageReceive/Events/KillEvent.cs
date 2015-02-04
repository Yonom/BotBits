using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("kill")]
    public sealed class KillEvent : PlayerEvent<KillEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="KillEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal KillEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
        }
    }
}