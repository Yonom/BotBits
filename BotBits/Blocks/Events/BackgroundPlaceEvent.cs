namespace BotBits.Events
{
    public sealed class BackgroundPlaceEvent : PlaceEvent<BackgroundPlaceEvent, BackgroundBlock>
    {
        internal BackgroundPlaceEvent(int x, int y, BlockData<BackgroundBlock> old, BlockData<BackgroundBlock> @new)
            : base(x, y, old, @new)
        {
        }
    }
}