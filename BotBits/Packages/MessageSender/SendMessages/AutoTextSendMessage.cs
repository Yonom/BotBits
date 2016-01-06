using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Sent to use auto-say  message.
    /// </summary>
    /// <seealso cref="SendMessage{T}" />
    public sealed class AutoTextSendMessage : SendMessage<AutoTextSendMessage>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AutoTextSendMessage" /> class.
        /// </summary>
        /// <param name="text">The text.</param>
        public AutoTextSendMessage(AutoText text)
        {
            this.Text = text;
        }

        /// <summary>
        ///     Gets or sets the text.
        /// </summary>
        /// <value>
        ///     The text.
        /// </value>
        public AutoText Text { get; set; }

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("autosay", (int) this.Text);
        }
    }
}