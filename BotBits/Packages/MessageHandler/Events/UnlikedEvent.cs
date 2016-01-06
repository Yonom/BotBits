using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when you successfully un-like the world.
    /// </summary>
    /// <seealso cref="ReceiveEvent{T}" />
    [ReceiveEvent("unliked")]
    public sealed class UnlikedEvent : ReceiveEvent<UnlikedEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="UnlikedEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal UnlikedEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
        }
    }
}