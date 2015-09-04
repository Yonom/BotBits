namespace BotBits
{
    public struct LayerItem<T> where T : struct
    {
        private readonly Point _location;
        private readonly T _data;

        public Point Location
        {
            get { return this._location; }
        }

        public T Data
        {
            get { return this._data; }
        }

        public LayerItem(Point location, T data)
        {
            this._location = location;
            this._data = data;
        }
    }
}
