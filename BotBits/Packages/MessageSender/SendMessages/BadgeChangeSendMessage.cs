using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Sent to change badge.
    /// </summary>
    /// <seealso cref="SendMessage{T}" />
    public sealed class BadgeChangeSendMessage : SendMessage<BadgeChangeSendMessage>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="BadgeChangeSendMessage" /> class.
        /// </summary>
        /// <param name="badge">The badge.</param>
        public BadgeChangeSendMessage(Badge badge) : this(badge.ToString())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BadgeChangeSendMessage"/> class.
        /// </summary>
        /// <param name="badgeId">The badge identifier.</param>
        public BadgeChangeSendMessage(string badgeId)
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