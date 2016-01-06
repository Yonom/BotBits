using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when a player changes badge.
    /// </summary>
    /// <seealso cref="PlayerEvent{T}" />
    [ReceiveEvent("badgeChange")]
    public sealed class BadgeEvent : PlayerEvent<BadgeEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="BadgeEvent" /> class.
        /// </summary>
        /// <param name="message">The EE message.</param>
        /// <param name="client"></param>
        internal BadgeEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.Badge = message.GetBadge(1);
        }

        /// <summary>
        ///     Gets or sets the badge.
        /// </summary>
        /// <value>The badge.</value>
        public Badge Badge { get; set; }
    }
}