using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when someone enables or disables the gold smiley border.
    /// </summary>
    /// <seealso cref="PlayerEvent{T}" />
    [ReceiveEvent("smileyGoldBorder")]
    public sealed class GoldBorderEvent : PlayerEvent<GoldBorderEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MutedEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal GoldBorderEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.GoldBorder = message.GetBoolean(1);
        }

        /// <summary>
        ///     Value indicating whether the player is wearing gold smiley border.
        /// </summary>
        /// <value><c>true</c> if muted; otherwise, <c>false</c>.</value>
        public bool GoldBorder { get; set; }
    }
}