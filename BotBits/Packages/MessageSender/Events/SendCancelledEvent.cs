using BotBits.SendMessages;
using JetBrains.Annotations;

namespace BotBits.Events
{
    /// <summary>
    ///     Raised when a queued SendMessage is cancelled.
    /// </summary>
    /// <remarks>This event is not delegated to the scheduler for performance optimizations.</remarks>
    public sealed class SendCancelledEvent<T> : Event<SendCancelledEvent<T>> where T : SendMessage<T>
    {
        public SendCancelledEvent([NotNull] T message)
        {
            this.Message = message;
        }

        public T Message { get; private set; }
    }
}