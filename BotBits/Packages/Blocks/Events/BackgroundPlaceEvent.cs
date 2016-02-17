namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when a background block is placed in the world.
    /// </summary>
    /// <seealso cref="PlaceEvent{T,TBlock}" />
    public sealed class BackgroundPlaceEvent : PlaceEvent<BackgroundPlaceEvent, BackgroundBlock>
    {
        internal BackgroundPlaceEvent(int x, int y, BlockData<BackgroundBlock> old, BlockData<BackgroundBlock> @new)
            : base(x, y, old, @new)
        {
        }
    }
}