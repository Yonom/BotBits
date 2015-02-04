using System;
using BotBits.Annotations;
using BotBits.Events;
using BotBits.SendMessages;

namespace BotBits
{
    /// <summary>
    /// Raised when a queued SendMessage is about to be sent.
    /// </summary>
    /// <remarks>This event is not delegated to the scheduler for performance optimizations.</remarks>
    public sealed class SendQueueEventArgs<T> : EventArgs where T : SendMessage<T>
    {
        public T Message { get; private set; }
        public bool Cancelled { get; set; }

        public SendQueueEventArgs([NotNull] T message)
        {
            this.Message = message;
        }
    }
}
