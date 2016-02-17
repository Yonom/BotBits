using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when a player received or lost ability to toggle god mode.
    /// </summary>
    /// <seealso cref="PlayerEvent{T}" />
    [ReceiveEvent("toggleGod")]
    public sealed class AllowToggleGodEvent : PlayerEvent<AllowToggleGodEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AllowToggleGodEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal AllowToggleGodEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.AllowToggle = message.GetBoolean(1);
        }

        /// <summary>
        ///     Gets or sets a value indicating whether player can toggle god mode.
        /// </summary>
        /// <value><c>true</c> if player can toggle god mode; otherwise, <c>false</c>.</value>
        public bool AllowToggle { get; set; }
    }
}