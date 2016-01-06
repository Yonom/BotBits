using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs shortly after join.
    ///     Contains information about chat message from before you joined world.
    /// </summary>
    /// <seealso cref="ReceiveEvent{T}" />
    [ReceiveEvent("say_old")]
    public sealed class OldChatEvent : ReceiveEvent<OldChatEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="OldChatEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal OldChatEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            Username = message.GetString(0);
            Text = message.GetString(1);
            Friend = message.GetBoolean(2);
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this player is my friend.
        /// </summary>
        /// <value><c>true</c> if this player is my friend; otherwise, <c>false</c>.</value>
        public bool Friend { get; set; }

        /// <summary>
        ///     Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text { get; set; }

        /// <summary>
        ///     Gets or sets the username.
        /// </summary>
        /// <value>The username.</value>
        public string Username { get; set; }
    }
}