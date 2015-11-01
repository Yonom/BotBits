namespace BotBits.Events
{
    public sealed class RespawnEvent : Event<RespawnEvent>
    {
        internal RespawnEvent(Player player, double x, double y, int deaths, bool resetCoins, bool causedByDeath)
        {
            this.Player = player;
            this.X = x;
            this.Y = y;
            this.Deaths = deaths;
            this.ResetCoins = resetCoins;
            this.CausedByDeath = causedByDeath;
        }

        public Player Player { get; private set; }
        public double X { get; }
        public double Y { get; }
        public int Deaths { get; set; }
        public bool ResetCoins { get; private set; }
        public bool CausedByDeath { get; set; }

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