using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when lobby preview is enabled or disabled.
    /// </summary>
    /// <seealso cref="ReceiveEvent{T}" />
    [ReceiveEvent("lobbyPreviewEnabled")]
    public sealed class LobbyPreviewEnabledEvent : ReceiveEvent<LobbyPreviewEnabledEvent>
    {
        internal LobbyPreviewEnabledEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.Enabled = message.GetBoolean(0);
        }

        /// <summary>
        ///     Gets or sets a value indicating whether lobby preview is enabled
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        public bool Enabled { get; set; }
    }
}