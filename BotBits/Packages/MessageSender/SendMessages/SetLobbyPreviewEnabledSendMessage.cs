using PlayerIOClient;

namespace BotBits.SendMessages
{
    public sealed class SetLobbyPreviewEnabledSendMessage : SendMessage<SetLobbyPreviewEnabledSendMessage>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SetLobbyPreviewEnabledSendMessage" /> class.
        /// </summary>
        /// <param name="enabled">if set to <c>true</c>, lobby preview is enabled.</param>
        public SetLobbyPreviewEnabledSendMessage(bool enabled)
        {
            this.Enabled = enabled;
        }

        /// <summary>
        ///     Gets or sets a value indicating whether lobby preview is enabled.
        /// </summary>
        /// <value>
        ///     <c>true</c> if enabled; otherwise, <c>false</c>.
        /// </value>
        public bool Enabled { get; set; }

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("setLobbyPreviewEnabled", this.Enabled);
        }
    }
}