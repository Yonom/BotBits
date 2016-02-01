using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when you are given edit rights in the world.
    /// </summary>
    /// <seealso cref="ReceiveEvent{T}" />
    [ReceiveEvent("access")]
    public sealed class AccessEvent : ReceiveEvent<AccessEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AccessEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal AccessEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
        }
    }
}