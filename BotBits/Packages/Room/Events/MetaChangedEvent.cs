namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when world metadata changes.
    /// </summary>
    /// <seealso cref="Event{T}" />
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

        /// <summary>
        ///     Gets the amount of favorites.
        /// </summary>
        /// <value>The amount of favorites.</value>
        public int Favorites { get; private set; }

        /// <summary>
        ///     Gets the owner's username.
        /// </summary>
        /// <value>The owner's username.</value>
        public string OwnerUsername { get; private set; }

        /// <summary>
        ///     Gets the amount of plays.
        /// </summary>
        /// <value>The amount of plays.</value>
        public int Plays { get; private set; }

        /// <summary>
        ///     Gets the amount of likes.
        /// </summary>
        /// <value>The amount of likes.</value>
        public int Likes { get; private set; }

        /// <summary>
        ///     Gets the name of the world.
        /// </summary>
        /// <value>The name of the world.</value>
        public string WorldName { get; private set; }
    }
}