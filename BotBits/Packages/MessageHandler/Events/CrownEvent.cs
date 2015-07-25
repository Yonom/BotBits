using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("k")]
    public sealed class CrownEvent : PlayerEvent<CrownEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CrownEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal CrownEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
        }
    }
}