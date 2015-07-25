using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("left")]
    public sealed class LeaveEvent : PlayerEvent<LeaveEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="LeaveEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal LeaveEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
        }
    }
}