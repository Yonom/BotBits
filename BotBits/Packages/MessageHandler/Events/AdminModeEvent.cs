using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when an administrator toggles administrator mode.
    /// </summary>
    /// <seealso cref="PlayerEvent{T}" />
    [ReceiveEvent("admin")]
    public sealed class AdminModeEvent : PlayerEvent<AdminModeEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AdminModeEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal AdminModeEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.Admin = message.GetBoolean(1);
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this player is in administrator mode.
        /// </summary>
        /// <value><c>true</c> if this player is in administrator mode; otherwise, <c>false</c>.</value>
        public bool Admin { get; set; }
    }
}