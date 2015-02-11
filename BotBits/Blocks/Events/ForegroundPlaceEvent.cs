namespace BotBits.Events
{
    public sealed class ForegroundPlaceEvent : PlaceEvent<ForegroundPlaceEvent, ForegroundBlock>
    {
        internal ForegroundPlaceEvent(int x, int y, BlockData<ForegroundBlock> old, BlockData<ForegroundBlock> @new)
            : base(x, y, old, @new)
        {
        }
    }
}