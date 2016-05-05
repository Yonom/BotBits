namespace BotBits
{
    public struct BlockData<T> where T : struct
    {
        private readonly Player _placer;

        public BlockData(Player placer, T block)
        {
            this._placer = placer;
            this.Block = block;
        }

        public BlockData(T block)
        {
            this._placer = Player.Nobody;
            this.Block = block;
        }

        public Player Placer => this._placer ?? Player.Nobody;

        public T Block { get; }
    }
}