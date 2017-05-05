namespace BotBits
{
    public struct ExpectedData<T> where T : struct
    {
        private readonly Player _placer;

        public ExpectedData(Player placer, T block, bool expected)
        {
            this._placer = placer;
            this.Block = block;
            this.Expected = expected;
        }
        
        public Player Placer => this._placer ?? Player.Nobody;

        public T Block { get; }
        public bool Expected { get; }
    }
}
