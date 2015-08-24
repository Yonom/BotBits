using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("liked")]
    public sealed class LikedEvent : ReceiveEvent<LikedEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="LikedEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal LikedEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
        }
    }
}