using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when new <see cref="PlayerIOClient.Message" /> is received.
    /// </summary>
    /// <seealso cref="Event{T}" />
    public sealed class PlayerIOMessageEvent : Event<PlayerIOMessageEvent>
    {
        internal PlayerIOMessageEvent(Message message)
        {
            this.Message = message;
        }

        /// <summary>
        ///     Gets the message.
        /// </summary>
        /// <value>The message.</value>
        public Message Message { get; private set; }
    }
}