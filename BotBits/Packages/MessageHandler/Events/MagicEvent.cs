using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when you are given magic reward.
    /// </summary>
    /// <seealso cref="ReceiveEvent{T}" />
    [ReceiveEvent("magic")]
    public sealed class MagicEvent : ReceiveEvent<MagicEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MagicEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal MagicEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
        }
    }
}