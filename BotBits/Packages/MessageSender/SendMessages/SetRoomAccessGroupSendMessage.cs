using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Sent to change world accessibility.
    /// </summary>
    /// <seealso cref="SendMessage{T}" />
    public sealed class SetRoomAccessGroupSendMessage : SendMessage<SetRoomAccessGroupSendMessage>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SetRoomAccessGroupSendMessage" /> class.
        /// </summary>
        /// <param name="visible">if set to <c>true</c> room becomes accessible.</param>
        /// <param name="friendsOnly">if set to <c>true</c> room becomes accessible to your friends only.</param>
        public SetRoomAccessGroupSendMessage(bool visible, bool friendsOnly)
        {
            this.Visible = visible;
            this.FriendsOnly = friendsOnly;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="SetRoomAccessGroupSendMessage" /> class.
        /// </summary>
        /// <param name="accessGroup">the access group that will have access to this room.</param>
        public SetRoomAccessGroupSendMessage(AccessGroup accessGroup)
        {
            this.AccessGroup = accessGroup;
        }

        /// <summary>
        ///     Gets or sets a value indicating whether the room should be visible.
        /// </summary>
        /// <value>
        ///     <c>true</c> if visible; otherwise, <c>false</c>.
        /// </value>
        public bool Visible { get; set; }

        public bool FriendsOnly { get; set; }

        public AccessGroup AccessGroup
        {
            get => this.Visible ? this.FriendsOnly ? AccessGroup.Friends : AccessGroup.Anyone : AccessGroup.Noone;
            set
            {
                this.Visible = value != AccessGroup.Noone;
                this.FriendsOnly = value == AccessGroup.Friends;
            }
        }

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("setRoomVisible", this.Visible, this.FriendsOnly);
        }
    }
}