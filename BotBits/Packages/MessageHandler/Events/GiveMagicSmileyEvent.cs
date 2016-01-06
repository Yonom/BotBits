using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when you are given magic smiley.
    /// </summary>
    /// <seealso cref="ReceiveEvent{T}" />
    [ReceiveEvent("givemagicsmiley")]
    public sealed class GiveMagicSmileyEvent : ReceiveEvent<GiveMagicSmileyEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GiveMagicSmileyEvent" /> class.
        /// </summary>
        /// <param name="client">The EE message.</param>
        /// <param name="message">The message.</param>
        internal GiveMagicSmileyEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            MagicSmiley = message.GetString(0);
        }

        /// <summary>
        ///     Gets or sets the magic smiley identifier.
        /// </summary>
        /// <value>The magic smiley.</value>
        public string MagicSmiley { get; set; }
    }
}