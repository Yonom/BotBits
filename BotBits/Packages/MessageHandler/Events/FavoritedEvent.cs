using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("favorited")]
    public sealed class FavoritedEvent : ReceiveEvent<FavoritedEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="FavoritedEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal FavoritedEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
        }
    }
}