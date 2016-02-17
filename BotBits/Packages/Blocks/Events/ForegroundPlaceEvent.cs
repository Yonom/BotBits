namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when a foreground block is placed in the world.
    /// </summary>
    /// <seealso cref="PlaceEvent{T,TBlock}" />
    public sealed class ForegroundPlaceEvent : PlaceEvent<ForegroundPlaceEvent, ForegroundBlock>
    {
        internal ForegroundPlaceEvent(int x, int y, BlockData<ForegroundBlock> old, BlockData<ForegroundBlock> @new)
            : base(x, y, old, @new)
        {
        }
    }
}