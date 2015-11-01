namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when a player's gold coin count changes.
    /// </summary>
    public sealed class BlueCoinEvent : Event<BlueCoinEvent>
    {
        internal BlueCoinEvent(Player player, int blueCoins, int x, int y)
        {
            this.Player = player;
            this.BlueCoins = blueCoins;
            this.X = x;
            this.Y = y;
        }

        public Player Player { get; private set; }
        public int BlueCoins { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
    }
}