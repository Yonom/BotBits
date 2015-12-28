using PlayerIOClient;

namespace BotBits.SendMessages
{
    public sealed class SetMinimapEnabledSendMessage : SendMessage<SetMinimapEnabledSendMessage>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SetMinimapEnabledSendMessage" /> class.
        /// </summary>
        /// <param name="enabled">if set to <c>true</c>, minimap is enabled.</param>
        public SetMinimapEnabledSendMessage(bool enabled)
        {
            this.Enabled = enabled;
        }

        /// <summary>
        ///     Gets or sets a value indicating whether minimap is enabled.
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
            return Message.Create("setMinimapEnabled", this.Enabled);
        }
    }
}