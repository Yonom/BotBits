using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Sent to say chat message.
    /// </summary>
    /// <seealso cref="SendMessage{T}" />
    public sealed class ChatSendMessage : SendMessage<ChatSendMessage>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ChatSendMessage" /> class.
        /// </summary>
        /// <param name="text">The text.</param>
        public ChatSendMessage(string text)
        {
            this.Text = text;
        }

        /// <summary>
        ///     Gets or sets the text.
        /// </summary>
        /// <value>
        ///     The text.
        /// </value>
        public string Text { get; set; }

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("say", this.Text);
        }
    }
}