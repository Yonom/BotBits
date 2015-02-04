using System.Collections.Generic;
using System.Linq;

namespace BotBits
{
    public sealed class EventHandle<T> where T : Event<T>
    {
        private readonly SortedDictionary<EventPriority, IList<EventRaiseHandler<T>>> _eventHandlers =
            new SortedDictionary<EventPriority, IList<EventRaiseHandler<T>>>();

        public int Count
        {
            get
            {
                lock (this._eventHandlers)
                {
                    return this._eventHandlers.Values.Sum(handlerGroup => handlerGroup.Count);
                }
            }
        }

        public void UnbindAll()
        {
            lock (this._eventHandlers)
            {
                this._eventHandlers.Clear();
            }
        }

        public bool Contains(EventRaiseHandler<T> item)
        {
            lock (this._eventHandlers)
            {
                return this._eventHandlers.Values.Any(handlerGroup => handlerGroup.Contains(item));
            }
        }

        public bool Unbind(EventRaiseHandler<T> item)
        {
            lock (this._eventHandlers)
            {
                return this._eventHandlers.Values.Any(handlerGroup => handlerGroup.Remove(item));
            }
        }

        public void Bind(EventRaiseHandler<T> callback, EventPriority priority = EventPriority.Normal)
        {
            lock (this._eventHandlers)
            {
                IList<EventRaiseHandler<T>> value;
                if (!this._eventHandlers.TryGetValue(priority, out value))
                {
                    value = new List<EventRaiseHandler<T>>();
                    this._eventHandlers.Add(priority, value);
                }

                value.Add(callback);
            }
        }

        internal void Raise(T e)
        {
            EventRaiseHandler<T>[] handlers;
            lock (this._eventHandlers)
            {
                handlers = this._eventHandlers.Values
                    .SelectMany(k => k)
                    .ToArray();
            }

            foreach (var handler in handlers)
            {
                handler(e);
            }
        }
    }
}