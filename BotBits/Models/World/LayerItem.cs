namespace BotBits
{
    public struct LayerItem<T> where T : struct
    {
        public Point Location { get; }

        public T Data { get; }

        public LayerItem(Point location, T data)
        {
            this.Location = location;
            this.Data = data;
        }
    }
}