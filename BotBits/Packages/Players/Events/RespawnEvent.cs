namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when a player is teleported. This event gets raised for
    ///     respawns of any kind, including death.
    /// </summary>
    /// <seealso cref="Event{T}" />
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

        /// <summary>
        ///     Gets the player.
        /// </summary>
        /// <value>The player.</value>
        public Player Player { get; private set; }

        /// <summary>
        ///     gets the x coordinate.
        /// </summary>
        /// <value>The x coordinate.</value>
        public double X { get; }

        /// <summary>
        ///     Gets the y coordinate.
        /// </summary>
        /// <value>The y coordinate.</value>
        public double Y { get; }

        /// <summary>
        ///     Gets or sets the deaths amount.
        /// </summary>
        /// <value>The deaths.</value>
        public int Deaths { get; set; }

        /// <summary>
        ///     Gets a value indicating whether player's stats should be reset.
        /// </summary>
        /// <value><c>true</c> if player's stats should be reset; otherwise, <c>false</c>.</value>
        public bool ResetCoins { get; private set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this event was caused by death.
        /// </summary>
        /// <value><c>true</c> if this event was caused by death; otherwise, <c>false</c>.</value>
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