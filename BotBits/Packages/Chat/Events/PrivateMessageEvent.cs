namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when a player sends a private message.
    /// </summary>
    /// <seealso cref="Event{T}" />
    public sealed class PrivateMessageEvent : Event<PrivateMessageEvent>
    {
        internal PrivateMessageEvent(string username, string message)
        {
            this.Username = username;
            this.Message = message;
        }

        /// <summary>
        ///     Gets the username of the player which sent the private message.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; private set; }

        /// <summary>
        ///     Gets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; private set; }
    }
}