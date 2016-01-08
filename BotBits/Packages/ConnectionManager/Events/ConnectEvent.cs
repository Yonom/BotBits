namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when connection with the Everybody Edits server is established.
    /// </summary>
    /// <seealso cref="Event{T}" />
    public sealed class ConnectEvent : Event<ConnectEvent>
    {
        internal ConnectEvent()
        {
        }
    }
}