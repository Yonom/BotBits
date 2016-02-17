using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when trying to join a world with a banned account.
    /// </summary>
    /// <seealso cref="ReceiveEvent{T}" />
    [ReceiveEvent("banned")]
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