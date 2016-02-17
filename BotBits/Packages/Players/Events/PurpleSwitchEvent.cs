namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when a player's purple switch state changes.
    /// </summary>
    /// <seealso cref="Event{T}" />
    public sealed class PurpleSwitchEvent : Event<PurpleSwitchEvent>
    {
        internal PurpleSwitchEvent(Player player, int switchId, bool enabled)
        {
            this.Enabled = enabled;
            this.SwitchId = switchId;
            this.Player = player;
        }

        /// <summary>
        ///     Gets the player.
        /// </summary>
        /// <value>The player.</value>
        public Player Player { get; private set; }

        /// <summary>
        ///     Gets the switch identifier.
        /// </summary>
        /// <value>The switch identifier.</value>
        public int SwitchId { get; private set; }

        /// <summary>
        ///     Gets a value indicating whether switch with the <see cref="SwitchId" /> is enabled.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        public bool Enabled { get; private set; }
    }
}