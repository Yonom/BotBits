using BotBits.SendMessages;
using JetBrains.Annotations;

namespace BotBits.Events
{
    /// <summary>
    ///     Raised when a queued SendMessage is sent.
    /// </summary>
    /// <remarks>This event is not delegated to the scheduler for performance optimizations.</remarks>
    public sealed class SendEvent<T> : Event<SendEvent<T>> where T : SendMessage<T>
    {
        public SendEvent([NotNull] T message)
        {
            this.Message = message;
        }

        public T Message { get; private set; }
    }
}