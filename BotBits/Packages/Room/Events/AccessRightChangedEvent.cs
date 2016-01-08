namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when player's access rights change.
    /// </summary>
    /// <seealso cref="Event{T}" />
    public sealed class AccessRightChangedEvent : Event<AccessRightChangedEvent>
    {
        internal AccessRightChangedEvent(AccessRight newRights)
        {
            this.NewRights = newRights;
        }

        /// <summary>
        ///     Gets the new rights.
        /// </summary>
        /// <value>The new rights.</value>
        public AccessRight NewRights { get; private set; }
    }
}