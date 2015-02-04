namespace BotBits.Events
{
    public sealed class NewPlayerEvent : Event<NewPlayerEvent>
    {
        internal NewPlayerEvent(Player player)
        {
            this.Player = player;
        }

        public Player Player { get; private set; }
    }
}