using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("w")]
    public sealed class MagicEvent : PlayerEvent<MagicEvent>
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