using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("completedLevel")]
    public sealed class CompletedLevelEvent : ReceiveEvent<CompletedLevelEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CompletedLevelEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal CompletedLevelEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
        }
    }
}