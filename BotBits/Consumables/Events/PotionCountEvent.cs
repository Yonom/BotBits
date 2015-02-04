namespace BotBits.Events
{
    public sealed class PotionCountEvent : Event<PotionCountEvent>
    {
        internal PotionCountEvent(Potion potion, int count)
        {
            this.Potion = potion;
            this.Count = count;
        }

        public Potion Potion { get; private set; }
        public int Count { get; private set; }
    }
}