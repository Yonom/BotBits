using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Sent to change hide lobby world setting.
    /// </summary>
    /// <seealso cref="SendMessage{T}" />
    public sealed class SetHideLobbySendMessage : SendMessage<SetHideLobbySendMessage>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SetHideLobbySendMessage" /> class.
        /// </summary>
        /// <param name="hidden">if set to <c>true</c> room becomes hidden in the lobby.</param>
        public SetHideLobbySendMessage(bool hidden)
        {
            this.Hidden = hidden;
        }

        /// <summary>
        ///     Gets or sets a value indicating whether the room should be hidden in the lobby.
        /// </summary>
        /// <value>
        ///     <c>true</c> if hidden; otherwise, <c>false</c>.
        /// </value>
        public bool Hidden { get; set; }

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("setHideLobby", this.Hidden);
        }
    }
}