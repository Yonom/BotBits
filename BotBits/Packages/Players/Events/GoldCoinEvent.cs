namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when a player's gold coin count changes.
    /// </summary>
    public sealed class GoldCoinEvent : Event<GoldCoinEvent>
    {
        internal GoldCoinEvent(Player player, int goldCoins, int x, int y)
        {
            this.Player = player;
            this.GoldCoins = goldCoins;
            this.X = x;
            this.Y = y;
        }

        public Player Player { get; private set; }
        public int GoldCoins { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
    }
}