namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when player's edit rights change.
    /// </summary>
    /// <seealso cref="Event{T}" />
    public sealed class EditRightChangedEvent : Event<EditRightChangedEvent>
    {
        internal EditRightChangedEvent(bool canEdit)
        {
            this.CanEdit = canEdit;
        }

        /// <summary>
        ///     Gets a value indicating whether the player can edit.
        /// </summary>
        /// <value><c>true</c> if this instance can edit; otherwise, <c>false</c>.</value>
        public bool CanEdit { get; private set; }
    }
}