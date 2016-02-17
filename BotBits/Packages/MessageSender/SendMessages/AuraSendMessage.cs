using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Sent to change aura shape and/or color.
    /// </summary>
    /// <seealso cref="SendMessage{T}" />
    public sealed class AuraSendMessage : SendMessage<AuraSendMessage>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AuraSendMessage" /> class.
        /// </summary>
        /// <param name="auraShape">The aura shape.</param>
        /// <param name="auraColor">The aura.</param>
        public AuraSendMessage(AuraShape auraShape, AuraColor auraColor)
        {
            this.AuraShape = auraShape;
            this.AuraColor = auraColor;
        }

        /// <summary>
        ///     Gets or sets your aura shape.
        /// </summary>
        /// <value>
        ///     The aura shape.
        /// </value>
        public AuraShape AuraShape { get; set; }

        /// <summary>
        ///     Gets or sets your aura color.
        /// </summary>
        /// <value>
        ///     The aura.
        /// </value>
        public AuraColor AuraColor { get; set; }

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("aura", (int) this.AuraShape, (int) this.AuraColor);
        }
    }
}