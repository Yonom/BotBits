namespace BotBits
{
    public struct SnapshotHistoryItem<T>
    {
        public Point Location { get; }
        public T OldBlock { get; }
        public T NewBlock { get; }

        public SnapshotHistoryItem(Point location, T oldBlock, T newBlock)
        {
            this.Location = location;
            this.OldBlock = oldBlock;
            this.NewBlock = newBlock;
        }
    }
}