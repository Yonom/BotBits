using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("muted")]
    public sealed class MutedEvent : PlayerEvent<MutedEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MutedEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal MutedEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.Muted = message.GetBoolean(1);
        }

        public bool Muted { get; set; }
    }
}
