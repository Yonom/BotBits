using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when a player uses auto-text.
    /// </summary>
    /// <seealso cref="PlayerEvent{T}" />
    [ReceiveEvent("autotext")]
    public sealed class AutoTextEvent : PlayerEvent<AutoTextEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AutoTextEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal AutoTextEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.AutoText = message.GetString(1);
        }

        /// <summary>
        ///     Gets or sets the automatic text value.
        /// </summary>
        /// <value>The automatic text.</value>
        public string AutoText { get; set; }
    }
}