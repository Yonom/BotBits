namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when connection with the Everybody Edits server is lost.
    /// </summary>
    /// <seealso cref="Event{T}" />
    public sealed class DisconnectEvent : Event<DisconnectEvent>
    {
        internal DisconnectEvent(string message)
        {
            this.Message = message;
        }

        /// <summary>
        ///     Gets or sets the disconnect message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }
    }
}