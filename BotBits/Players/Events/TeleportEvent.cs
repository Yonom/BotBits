namespace BotBits.Events
{
    public sealed class TeleportEvent : Event<TeleportEvent>
    {
        internal TeleportEvent(Player player, Point point)
        {
            this.Player = player;
            this.Point = point;
        }

        public Player Player { get; private set; }
        public Point Point { get; private set; }
    }
}