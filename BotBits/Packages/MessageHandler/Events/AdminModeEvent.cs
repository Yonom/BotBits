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
            this.AdminMode = message.GetBoolean(1);
            this.StaffAuraOffset = message.GetInt(2);
        }

        public int StaffAuraOffset { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this player is in administrator mode.
        /// </summary>
        /// <value><c>true</c> if this player is in administrator mode; otherwise, <c>false</c>.</value>
        public bool AdminMode { get; set; }
    }
}