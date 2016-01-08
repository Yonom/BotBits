namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when a player's gold coin count changes.
    /// </summary>
    /// <seealso cref="Event{T}" />
    public sealed class GoldCoinEvent : Event<GoldCoinEvent>
    {
        internal GoldCoinEvent(Player player, int goldCoins, int x, int y)
        {
            this.Player = player;
            this.GoldCoins = goldCoins;
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        ///     Gets the player.
        /// </summary>
        /// <value>The player.</value>
        public Player Player { get; private set; }

        /// <summary>
        ///     Gets the gold coins count.
        /// </summary>
        /// <value>The gold coins.</value>
        public int GoldCoins { get; private set; }

        /// <summary>
        ///     Gets the x coordinate.
        /// </summary>
        /// <value>The x.</value>
        public int X { get; private set; }

        /// <summary>
        ///     Gets the y coordinate.
        /// </summary>
        /// <value>The y coordinate.</value>
        public int Y { get; private set; }
    }
}