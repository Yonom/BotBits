using System;
using JetBrains.Annotations;
using BotBits.Events;
using BotBits.SendMessages;

namespace BotBits
{
    /// <summary>
    /// Raised when a queued SendMessage is about to be sent.
    /// </summary>
    /// <remarks>This event is not delegated to the scheduler for performance optimizations.</remarks>
    public sealed class SendingEventArgs<T> : EventArgs where T : SendMessage<T>
    {
        public T Message { get; private set; }
        public bool Cancelled { get; set; }

        public SendingEventArgs([NotNull] T message)
        {
            this.Message = message;
        }
    }

    /// <summary>
    /// Raised when a queued SendMessage is sent.
    /// </summary>
    /// <remarks>This event is not delegated to the scheduler for performance optimizations.</remarks>
    public sealed class SendEventArgs<T> : EventArgs where T : SendMessage<T>
    {
        public T Message { get; private set; }

        public SendEventArgs([NotNull] T message)
        {
            this.Message = message;
        }
    }
}
