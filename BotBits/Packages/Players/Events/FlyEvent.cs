namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when a player's flying status changes
    /// </summary>
    public sealed class FlyEvent : Event<FlyEvent>
    {
        internal FlyEvent(Player player, bool flying)
        {
            this.Player = player;
            this.Flying = flying;
        }

        public Player Player { get; private set; }
        public bool Flying { get; private set; }
    }
}