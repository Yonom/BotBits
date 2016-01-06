using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Sent to change badge.
    /// </summary>
    /// <seealso cref="SendMessage{T}" />
    public sealed class BadgeSendMessage : SendMessage<BadgeSendMessage>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="BadgeSendMessage" /> class.
        /// </summary>
        /// <param name="badge">The badge.</param>
        public BadgeSendMessage(Badge badge) : this(badge.ToString())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BadgeSendMessage"/> class.
        /// </summary>
        /// <param name="badgeId">The badge identifier.</param>
        public BadgeSendMessage(string badgeId)
        {
            this.Badge = badgeId;
        }

        /// <summary>
        ///     Gets or sets the badge.
        /// </summary>
        /// <value>
        ///     The badge.
        /// </value>
        public string Badge { get; set; }

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("changeBadge", this.Badge);
        }
    }
}