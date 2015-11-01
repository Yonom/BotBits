using System;
using System.Threading;
using JetBrains.Annotations;

namespace BotBits
{
    public abstract class Event<T> : IEvent where T : Event<T>
    {
        private int _isRaised;

        protected Event()
        {
            var a = typeof (T);
            if (a != this.GetType())
                throw new InvalidOperationException("Events must inherit Event<T> of their own type!");
            if (!a.IsSealed)
                throw new InvalidOperationException("Events must be marked as sealed.");
        }

        public virtual void RaiseIn([NotNull] BotBitsClient client)
        {
            if (Interlocked.Exchange(ref this._isRaised, 1) == 1)
                throw new InvalidOperationException("This event can only be raised once.");

            Of(client).Raise((T) this);
        }

        [Pure]
        public static EventHandle<T> Of([NotNull] BotBitsClient client)
        {
            return EventManager.Of(client).GetEvent<T>();
        }
    }
}