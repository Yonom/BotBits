using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when a player changes aura shape or color.
    /// </summary>
    /// <seealso cref="PlayerEvent{T}" />
    [ReceiveEvent("aura")]
    public sealed class AuraEvent : PlayerEvent<AuraEvent>
    {
        internal AuraEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            AuraShape = (AuraShape) message.GetInt(1);
            AuraColor = (AuraColor) message.GetInt(2);
        }

        /// <summary>
        ///     Gets or sets the aura shape.
        /// </summary>
        /// <value>The aura shape.</value>
        public AuraShape AuraShape { get; set; }

        /// <summary>
        ///     Gets or sets the color of the aura.
        /// </summary>
        /// <value>The color of the aura.</value>
        public AuraColor AuraColor { get; set; }
    }
}