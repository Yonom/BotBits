namespace BotBits.Events
{
    public sealed class BlueCoinEvent : Event<BlueCoinEvent>
    {
        internal BlueCoinEvent(Player player, int count)
        {
            this.Player = player;
            this.Count = count;
        }

        public Player Player { get; private set; }
        public int Count { get; private set; }
    }
}