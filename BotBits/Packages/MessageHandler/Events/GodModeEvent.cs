using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when a player toggles god mode.
    /// </summary>
    /// <seealso cref="PlayerEvent{T}" />
    [ReceiveEvent("god")]
    public sealed class GodModeEvent : PlayerEvent<GodModeEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GodModeEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal GodModeEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.GodMode = message.GetBoolean(1);
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this player is in god mode.
        /// </summary>
        /// <value><c>true</c> if this player is in god mode; otherwise, <c>false</c>.</value>
        public bool GodMode { get; set; }
    }
}