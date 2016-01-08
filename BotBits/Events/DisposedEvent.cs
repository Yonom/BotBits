namespace BotBits.Events
{
    /// <summary>
    ///     Occurs after <see cref="BotBitsClient" /> has been disposed.
    /// </summary>
    /// <seealso cref="Event{T}" />
    public sealed class DisposedEvent : Event<DisposedEvent>
    {
    }
}