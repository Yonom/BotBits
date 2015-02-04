using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("guardian")]
    public sealed class GuardianModeEvent : PlayerEvent<GuardianModeEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GuardianModeEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal GuardianModeEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.Guardian = message.GetBoolean(1);
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this player is in guardian mode.
        /// </summary>
        /// <value><c>true</c> if this player is in guardian mode; otherwise, <c>false</c>.</value>
        public bool Guardian { get; set; }
    }
}