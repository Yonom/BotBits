using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("unfavorited")]
    public sealed class UnfavoritedEvent : ReceiveEvent<UnfavoritedEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="UnfavoritedEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal UnfavoritedEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
        }
    }
}