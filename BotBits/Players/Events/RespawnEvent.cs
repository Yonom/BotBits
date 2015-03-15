namespace BotBits.Events
{
    public sealed class RespawnEvent : Event<RespawnEvent>
    {
        internal RespawnEvent(Player player, int x, int y, bool resetCoins)
        {
            this.Player = player;
            this.X = x;
            this.Y = y;
            this.ResetCoins = resetCoins;
        }

        public Player Player { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public bool ResetCoins { get; private set; }

        /// <summary>
        ///     Gets the block x.
        /// </summary>
        /// <value>The block x.</value>
        public int BlockX
        {
            get { return WorldUtils.PosToBlock(this.X); }
        }

        /// <summary>
        ///     Gets the block y.
        /// </summary>
        /// <value>The block y.</value>
        public int BlockY
        {
            get { return WorldUtils.PosToBlock(this.Y); }
        }
    }
}