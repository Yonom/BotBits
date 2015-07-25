using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("access")]
    public sealed class AccessEvent : ReceiveEvent<AccessEvent>
    {
        //No arguments

        /// <summary>
        ///     Initializes a new instance of the <see cref="AccessEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal AccessEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
        }
    }
}