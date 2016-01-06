using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Sent to toggle god mode.
    /// </summary>
    /// <seealso cref="SendMessage{T}" />
    public sealed class GodModeSendMessage : SendMessage<GodModeSendMessage>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GodModeSendMessage" /> class.
        /// </summary>
        /// <param name="godModeEnabled">if set to <c>true</c> then god mode enabled.</param>
        public GodModeSendMessage(bool godModeEnabled)
        {
            this.GodModeEnabled = godModeEnabled;
        }

        /// <summary>
        ///     Gets or sets a value indicating whether god mode is enabled.
        /// </summary>
        /// <value>
        ///     <c>true</c> if god mode is enabled; otherwise, <c>false</c>.
        /// </value>
        public bool GodModeEnabled { get; set; }

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("god", this.GodModeEnabled);
        }
    }
}