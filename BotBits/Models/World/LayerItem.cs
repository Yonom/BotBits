namespace BotBits
{
    public struct LayerItem<T> where T : struct
    {
        public int X { get; }
        public int Y { get; }

        public T Data { get; }

        public LayerItem(T data, int x, int y)
        {
            this.Data = data;
            this.X = x;
            this.Y = y;
        }
    }
}