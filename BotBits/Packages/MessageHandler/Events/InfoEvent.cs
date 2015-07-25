using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when the server sends information pertaining to low-level functions like (a) you were kicked or (b) the room
    ///     is full or (c) rate limit exceeded.
    /// </summary>
    [ReceiveEvent("info")]
    public sealed class InfoEvent : ReceiveEvent<InfoEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="InfoEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal InfoEvent(BotBitsClient client, Message message)
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