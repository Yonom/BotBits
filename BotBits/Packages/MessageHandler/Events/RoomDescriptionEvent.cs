using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when world description is changed.
    /// </summary>
    /// <seealso cref="ReceiveEvent{T}" />
    [ReceiveEvent("roomDescription")]
    public sealed class RoomDescriptionEvent : ReceiveEvent<RoomDescriptionEvent>
    {
        internal RoomDescriptionEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.Description = message.GetString(0);
        }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>The description.</value>
        public string Description { get; set; }
    }
}