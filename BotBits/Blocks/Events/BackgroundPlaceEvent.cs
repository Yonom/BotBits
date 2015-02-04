namespace BotBits.Events
{
    public sealed class BackgroundPlaceEvent : PlaceEvent<BackgroundPlaceEvent, BackgroundBlock>
    {
        internal BackgroundPlaceEvent(int x, int y, BackgroundBlock oldBlock, BackgroundBlock newBlock, Player player)
            : base(x, y, oldBlock, newBlock, player)
        {
        }
    }
}