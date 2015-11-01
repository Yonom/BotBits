using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("init2")]
    public sealed class JoinCompleteEvent : ReceiveEvent<JoinCompleteEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="JoinCompleteEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal JoinCompleteEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
        }
    }
}