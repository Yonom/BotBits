namespace BotBits.Events
{
    /// <summary>
    ///     Occurs before <see cref="BotBitsClient" /> is disposed.
    /// </summary>
    /// <seealso cref="Event{T}" />
    public sealed class DisposingEvent : Event<DisposingEvent>
    {
    }
}