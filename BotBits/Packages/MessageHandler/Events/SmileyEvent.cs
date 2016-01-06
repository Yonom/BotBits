using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when someone changes their smiley.
    /// </summary>
    /// <seealso cref="PlayerEvent{T}" />
    [ReceiveEvent("face")]
    public sealed class SmileyEvent : PlayerEvent<SmileyEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SmileyEvent" /> class.
        /// </summary>
        /// <param name="message">The EE message.</param>
        /// <param name="client"></param>
        internal SmileyEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            Smiley = (Smiley) message.GetInteger(1);
        }

        /// <summary>
        ///     Gets or sets the smiley.
        /// </summary>
        /// <value>The smiley.</value>
        public Smiley Smiley { get; set; }
    }
}