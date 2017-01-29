namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when joining a room fails.
    /// </summary>
    /// <seealso cref="Event{T}" />
    public sealed class JoinFailureEvent : Event<JoinFailureEvent>
    {
        public string Title { get; set; }
        public string Reason { get; set; }

        internal JoinFailureEvent(string title, string reason)
        {
            this.Title = title;
            this.Reason = reason;
        }
    }
}
