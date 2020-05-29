using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when a staff member toggles staff mode.
    /// </summary>
    /// <seealso cref="PlayerEvent{T}" />
    [ReceiveEvent("mod")]
    public sealed class StaffModeEvent : PlayerEvent<StaffModeEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="StaffModeEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal StaffModeEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.StaffMode = message.GetBoolean(1);
        }

        /// <summary>
        ///     Gets or sets a value indicating whether the staff member is in staff mode.
        /// </summary>
        /// <value><c>true</c> if in staff mode; otherwise, <c>false</c>.</value>
        public bool StaffMode { get; set; }
    }
}
