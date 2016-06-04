using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Sent to enable or disable the gold smiley border
    /// </summary>
    /// <seealso cref="SendMessage{T}" />
    public sealed class SmileyGoldBolderSendMessage : SendMessage<SmileyGoldBolderSendMessage>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SmileyGoldBolderSendMessage" /> class.
        /// </summary>
        /// <param name="enabled">if set to <c>true</c>, minimap is enabled.</param>
        public SmileyGoldBolderSendMessage(bool enabled)
        {
            this.Enabled = enabled;
        }

        /// <summary>
        ///     Gets or sets a value indicating whether the gold smiley border should be enabled.
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
            return Message.Create("smileyGoldBorder", this.Enabled);
        }
    }
}