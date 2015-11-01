using System;
using BotBits.SendMessages;
using JetBrains.Annotations;

namespace BotBits
{
    /// <summary>
    ///     Raised when a queued SendMessage is about to be sent.
    /// </summary>
    /// <remarks>This event is not delegated to the scheduler for performance optimizations.</remarks>
    public sealed class SendingEventArgs<T> : EventArgs where T : SendMessage<T>
    {
        public SendingEventArgs([NotNull] T message)
        {
            this.Message = message;
        }

        public T Message { get; private set; }
        public bool Cancelled { get; set; }
    }

    /// <summary>
    ///     Raised when a queued SendMessage is sent.
    /// </summary>
    /// <remarks>This event is not delegated to the scheduler for performance optimizations.</remarks>
    public sealed class SendEventArgs<T> : EventArgs where T : SendMessage<T>
    {
        public SendEventArgs([NotNull] T message)
        {
            this.Message = message;
        }

        public T Message { get; private set; }
    }
}