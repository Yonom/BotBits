using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("saved")]
    public sealed class SavedEvent : ReceiveEvent<SavedEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SavedEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal SavedEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
        }
    }
}