namespace BotBits.Events
{
    public class PlaceEvent<T, TBlock> : Event<T>
        where T : PlaceEvent<T, TBlock> 
        where TBlock : struct
    {
        internal PlaceEvent(int x, int y, BlockData<TBlock> old, BlockData<TBlock> @new)
        {
            this.X = x;
            this.Y = y;
            this.Old = old;
            this.New = @new;
        }

        public int X { get; private set; }
        public int Y { get; private set; }
        public BlockData<TBlock> Old { get; private set; }
        public BlockData<TBlock> New { get; private set; }
    }
}