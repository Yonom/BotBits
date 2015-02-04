using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("pc")]
    public sealed class PotionsCountEvent : ReceiveEvent<PotionsCountEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PotionsCountEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal PotionsCountEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
        }
    }
}