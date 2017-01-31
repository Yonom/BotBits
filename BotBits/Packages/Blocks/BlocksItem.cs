namespace BotBits
{
    public struct BlocksItem : IBlockSettable<ForegroundBlock, BackgroundBlock>
    {
        private readonly Blocks _blocks;

        public int X { get; }

        public int Y { get; }

        public BlockData<ForegroundBlock> Foreground => this._blocks.Foreground[this.X, this.Y];

        public BlockData<BackgroundBlock> Background => this._blocks.Background[this.X, this.Y];

        public BlocksItem(Blocks blocks, int x, int y)
        {
            this._blocks = blocks;
            this.X = x;
            this.Y = y;
        }

        public void Set(ForegroundBlock block)
        {
            this._blocks.Place(this.X, this.Y, block);
        }

        public void Set(BackgroundBlock block)
        {
            this._blocks.Place(this.X, this.Y, block);
        }
    }
}