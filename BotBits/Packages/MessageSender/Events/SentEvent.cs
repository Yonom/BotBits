using BotBits.SendMessages;
using JetBrains.Annotations;

namespace BotBits.Events
{
    /// <summary>
    ///     Raised when a queued SendMessage is sent.
    /// </summary>
    /// <remarks>This event is not delegated to the scheduler for performance optimizations.</remarks>
    public sealed class SentEvent<T> : Event<SentEvent<T>> where T : SendMessage<T>
    {
        public SentEvent([NotNull] T message)
        {
            this.Message = message;
        }

        public T Message { get; private set; }
    }
}