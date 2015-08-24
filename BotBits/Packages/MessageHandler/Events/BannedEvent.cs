using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("Banned")]
    public sealed class BannedEvent : ReceiveEvent<BannedEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="BannedEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal BannedEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
        }
    }
}