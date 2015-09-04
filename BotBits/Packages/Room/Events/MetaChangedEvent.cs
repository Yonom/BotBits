namespace BotBits.Events
{
    public sealed class MetaChangedEvent : Event<MetaChangedEvent>
    {
        internal MetaChangedEvent(string ownerUsername, int plays, int favorites, int likes, string worldName)
        {
            this.OwnerUsername = ownerUsername;
            this.Plays = plays;
            this.Favorites = favorites;
            this.Likes = likes;
            this.WorldName = worldName;
        }

        public int Favorites { get; private set; }
        public string OwnerUsername { get; private set; }
        public int Plays { get; private set; }
        public int Likes { get; private set; }
        public string WorldName { get; private set; }
    }
}