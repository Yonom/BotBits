using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when world accessibility is changed.
    /// </summary>
    /// <seealso cref="ReceiveEvent{T}" />
    [ReceiveEvent("roomVisible")]
    public sealed class RoomAccessGroupEvent : ReceiveEvent<RoomAccessGroupEvent>
    {
        internal RoomAccessGroupEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.Visible = message.GetBoolean(0);
            this.FriendsOnly = message.GetBoolean(1);
        }

        /// <summary>
        ///     Gets or sets a value indicating whether world is accessible to your friends only.
        /// </summary>
        /// <value><c>true</c> if world is accessible to your friends only; otherwise, <c>false</c>.</value>
        public bool FriendsOnly { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether world is accessible.
        /// </summary>
        /// <value><c>true</c> if world is accessible; otherwise, <c>false</c>.</value>
        public bool Visible { get; set; }

        public AccessGroup AccessGroup
        {
            get => this.Visible ? this.FriendsOnly ? AccessGroup.Friends : AccessGroup.Anyone : AccessGroup.Noone;
            set
            {
                this.Visible = value != AccessGroup.Noone;
                this.FriendsOnly = value == AccessGroup.Friends;
            }
        }
    }
}