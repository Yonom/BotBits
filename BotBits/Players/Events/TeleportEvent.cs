namespace BotBits.Events
{
    public sealed class TeleportEvent : Event<TeleportEvent>
    {
        internal TeleportEvent(Player player, int x, int y)
        {
            this.Player = player;
            this.X = x;
            this.Y = y;
        }

        public Player Player { get; private set; }
        public int X { get; private set; }
        public int Y { get; private set; }

        /// <summary>
        ///     Gets the block x.
        /// </summary>
        /// <value>The block x.</value>
        public int BlockX
        {
            get { return BlockUtils.PosToBlock(this.X); }
        }

        /// <summary>
        ///     Gets the block y.
        /// </summary>
        /// <value>The block y.</value>
        public int BlockY
        {
            get { return BlockUtils.PosToBlock(this.Y); }
        }
    }
}