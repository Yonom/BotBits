namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when the world size changes.
    /// </summary>
    /// <seealso cref="Event{T}" />
    public sealed class WorldResizeEvent : Event<WorldResizeEvent>
    {
        internal WorldResizeEvent(int newWidth, int newHeight)
        {
            this.NewHeight = newHeight;
            this.NewWidth = newWidth;
        }

        /// <summary>
        ///     Gets the new height.
        /// </summary>
        /// <value>
        ///     The new height.
        /// </value>
        public int NewHeight { get; private set; }

        /// <summary>
        ///     Gets the new width.
        /// </summary>
        /// <value>
        ///     The new width.
        /// </value>
        public int NewWidth { get; private set; }
    }
}