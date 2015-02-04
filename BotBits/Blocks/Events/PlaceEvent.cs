namespace BotBits.Events
{
    public class PlaceEvent<T, TBlock> : Event<T>
        where T : PlaceEvent<T, TBlock> 
        where TBlock : struct
    {
        internal PlaceEvent(int x, int y, TBlock oldBlock, TBlock newBlock, Player player)
        {
            this.X = x;
            this.Y = y;
            this.OldBlock = oldBlock;
            this.NewBlock = newBlock;
            this.Player = player;
        }

        public int X { get; private set; }
        public int Y { get; private set; }
        public TBlock OldBlock { get; private set; }
        public TBlock NewBlock { get; private set; }
        public Player Player { get; private set; }
    }
}