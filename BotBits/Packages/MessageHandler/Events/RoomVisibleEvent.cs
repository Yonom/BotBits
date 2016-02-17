using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when world accessibility is changed.
    /// </summary>
    /// <seealso cref="ReceiveEvent{T}" />
    [ReceiveEvent("roomVisible")]
    public sealed class RoomVisibleEvent : ReceiveEvent<RoomVisibleEvent>
    {
        internal RoomVisibleEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.Visible = message.GetBoolean(0);
        }

        /// <summary>
        ///     Gets or sets a value indicating whether world is accessible.
        /// </summary>
        /// <value><c>true</c> if world is accessible; otherwise, <c>false</c>.</value>
        public bool Visible { get; set; }
    }
}