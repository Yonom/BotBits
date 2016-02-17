namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when a player's flying status changes.
    /// </summary>
    /// <seealso cref="Event{T}" />
    public sealed class FlyEvent : Event<FlyEvent>
    {
        internal FlyEvent(Player player, bool flying)
        {
            this.Player = player;
            this.Flying = flying;
        }

        /// <summary>
        ///     Gets the player.
        /// </summary>
        /// <value>The player.</value>
        public Player Player { get; private set; }

        /// <summary>
        ///     Gets a value indicating whether the player is flying.
        /// </summary>
        /// <value><c>true</c> if flying; otherwise, <c>false</c>.</value>
        public bool Flying { get; private set; }
    }
}