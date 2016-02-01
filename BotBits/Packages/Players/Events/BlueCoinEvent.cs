namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when a player's gold coin count changes.
    /// </summary>
    /// <seealso cref="Event{T}" />
    public sealed class BlueCoinEvent : Event<BlueCoinEvent>
    {
        internal BlueCoinEvent(Player player, int blueCoins, int x, int y)
        {
            this.Player = player;
            this.BlueCoins = blueCoins;
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        ///     Gets the player.
        /// </summary>
        /// <value>The player.</value>
        public Player Player { get; private set; }

        /// <summary>
        ///     Gets the blue coins count.
        /// </summary>
        /// <value>The blue coins.</value>
        public int BlueCoins { get; private set; }

        /// <summary>
        ///     Gets the x coordinate.
        /// </summary>
        /// <value>The x coordinate.</value>
        public int X { get; private set; }

        /// <summary>
        ///     Gets the y coordinate.
        /// </summary>
        /// <value>The y coordinate.</value>
        public int Y { get; private set; }
    }
}