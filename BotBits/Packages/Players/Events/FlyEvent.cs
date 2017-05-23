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

    /// <summary>
    ///     Occurs when a player enters mod or admin mode.
    /// </summary>
    /// <seealso cref="Event{T}" />
    public sealed class StaffModeEvent : Event<FlyEvent>
    {
        internal StaffModeEvent(Player player, bool staffMode)
        {
            this.Player = player;
            this.StaffMode = staffMode;
        }

        /// <summary>
        ///     Gets the player.
        /// </summary>
        /// <value>The player.</value>
        public Player Player { get; private set; }

        /// <summary>
        ///     Gets a value indicating whether the player is in mod or admin mode.
        /// </summary>
        /// <value><c>true</c> if in mod or admin mode; otherwise, <c>false</c>.</value>
        public bool StaffMode { get; private set; }
    }
}