using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when a non-player message is received. (System messages, etc.)
    /// </summary>
    [ReceiveEvent("write")]
    public sealed class WriteEvent : ReceiveEvent<WriteEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="WriteEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal WriteEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.Title = message.GetString(0);
            this.Text = message.GetString(1);
        }

        /// <summary>
        ///     Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text { get; set; }

        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }
    }
}