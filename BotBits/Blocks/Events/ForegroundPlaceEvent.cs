namespace BotBits.Events
{
    public sealed class ForegroundPlaceEvent : PlaceEvent<ForegroundPlaceEvent, ForegroundBlock>
    {
        internal ForegroundPlaceEvent(int x, int y, ForegroundBlock oldBlock, ForegroundBlock newBlock, Player player)
            : base(x, y, oldBlock, newBlock, player)
        {
        }
    }
}