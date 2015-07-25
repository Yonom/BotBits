using System;
using System.Collections.Concurrent;

namespace BotBits
{
    internal sealed class EventManager : Package<EventManager>
    {
        private readonly ConcurrentDictionary<Type, object> _eventHandler = new ConcurrentDictionary<Type, object>();

        [Obsolete("Invalid to use \"new\" on this class. Use the static .Of(botBits) method instead.", true)]
        public EventManager()
        {
        }

        public EventHandle<T> GetEvent<T>() where T : Event<T>
        {
            return (EventHandle<T>)this._eventHandler.GetOrAdd(typeof(T), t => new EventHandle<T>());
        }
    }
}