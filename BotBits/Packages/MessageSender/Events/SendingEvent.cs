using BotBits.SendMessages;
using JetBrains.Annotations;

namespace BotBits.Events
{
    /// <summary>
    ///     Raised when a queued SendMessage is about to be sent.
    /// </summary>
    /// <remarks>This event is not delegated to the scheduler for performance optimizations.</remarks>
    public sealed class SendingEvent<T> : Event<SendingEvent<T>>  where T : SendMessage<T>
    {
        public SendingEvent([NotNull] T message)
        {
            this.Message = message;
        }

        public T Message { get; private set; }
        public bool Cancelled { get; set; }
    }
}