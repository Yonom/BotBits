using PlayerIOClient;

namespace BotBits.SendMessages
{
    public sealed class SetRoomVisibleSendMessage : SendMessage<SetRoomVisibleSendMessage>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SetEditKeySendMessage" /> class.
        /// </summary>
        /// <param name="visible">if set to <c>true</c> room becomes visible.</param>
        public SetRoomVisibleSendMessage(bool visible)
        {
            this.Visible = visible;
        }

        /// <summary>
        ///     Gets or sets a value indicating whether the room should be visible.
        /// </summary>
        /// <value>
        ///     <c>true</c> if visible; otherwise, <c>false</c>.
        /// </value>
        public bool Visible { get; set; }

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("setRoomVisible", this.Visible);
        }
    }
}