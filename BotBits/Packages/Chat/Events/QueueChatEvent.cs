namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when a new chat message is added to the chat send queue.
    /// </summary>
    /// <seealso cref="Event{T}" />
    public sealed class QueueChatEvent : Event<QueueChatEvent>
    {
        public QueueChatEvent(string message)
        {
            this.Message = message;
        }

        /// <summary>
        ///     Gets or sets the chat message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="QueueChatEvent" /> is cancelled.
        /// </summary>
        /// <value><c>true</c> if cancelled; otherwise, <c>false</c>.</value>
        public bool Cancelled { get; set; }
    }
}