using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("say")]
    public sealed class ChatEvent : PlayerEvent<ChatEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ChatEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal ChatEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.Text = message.GetString(1);
            this.Friend = message.GetBoolean(2);
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this player is your friend.
        /// </summary>   
        /// <value><c>true</c> if this player is your friend; otherwise, <c>false</c>.</value>
        public bool Friend { get; set; }

        /// <summary>
        ///     Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text { get; set; }
    }
}