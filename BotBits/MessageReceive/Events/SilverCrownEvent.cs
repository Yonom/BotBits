using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("ks")]
    public sealed class SilverCrownEvent : PlayerEvent<SilverCrownEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SilverCrownEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal SilverCrownEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
        }
    }
}