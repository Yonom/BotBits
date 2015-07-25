namespace BotBits.Events
{
    public sealed class GoldCoinEvent : Event<GoldCoinEvent>
    {
        internal GoldCoinEvent(Player player, int count)
        {
            this.Player = player;
            this.Count = count;
        }

        public Player Player { get; private set; }
        public int Count { get; private set; }
    }
}