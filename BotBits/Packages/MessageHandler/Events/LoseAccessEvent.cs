using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when you lose edit rights.
    /// </summary>
    /// <seealso cref="ReceiveEvent{T}" />
    [ReceiveEvent("lostaccess")]
    public sealed class LoseAccessEvent : ReceiveEvent<LoseAccessEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="LoseAccessEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal LoseAccessEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
        }
    }
}