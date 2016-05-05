using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;

namespace BotBits
{
    public sealed class EventHandle<T> where T : Event<T>
    {
        private readonly EventHandlerCollection _eventHandlers =
            new EventHandlerCollection();

        internal EventHandle(BotBitsClient botBits)
        {
            this.BotBits = botBits;
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public BotBitsClient BotBits { get; }

        public int Count
        {
            get
            {
                lock (this._eventHandlers)
                {
                    return this._eventHandlers.Values.Sum(ex => ex.Values.Sum(pr => pr.Values.Sum(l => l.Count)));
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
                return this._eventHandlers.Handlers.Any(h => h == item);
            }
        }

        public bool Unbind(EventRaiseHandler<T> item)
        {
            lock (this._eventHandlers)
            {
                return this._eventHandlers.Remove(item);
            }
        }

        public void Bind(EventRaiseHandler<T> callback, EventPriority priority = EventPriority.Normal)
        {
            this.Bind(callback, GlobalPriority.Normal, priority);
        }

        public void Bind(EventRaiseHandler<T> callback, GlobalPriority globalPriority,
            EventPriority priority = EventPriority.Normal)
        {
            var assembly = callback.Method.DeclaringType?.Assembly;
            this.BindInternal(assembly, callback, globalPriority, priority);
        }

        internal void BindInternal([CanBeNull] Assembly assembly, EventRaiseHandler<T> callback, GlobalPriority globalPriority,
            EventPriority priority)
        {
            lock (this._eventHandlers)
            {
                var extensionId = ExtensionServices.GetExtensionId(this.BotBits, assembly);
                this._eventHandlers.Add(globalPriority, extensionId ?? int.MaxValue, priority, callback);
            }
        }

        internal void Raise(T e)
        {
            EventRaiseHandler<T>[] handlers;
            lock (this._eventHandlers)
            {
                handlers = this._eventHandlers.Handlers.ToArray();
            }

            foreach (var handler in handlers)
            {
                handler(e);
            }
        }

        private class EventHandlerCollection :
            SortedDictionary<GlobalPriority,
                SortedDictionary<int,
                    SortedDictionary<EventPriority,
                        List<EventRaiseHandler<T>>>>>
        {
            public IEnumerable<EventRaiseHandler<T>> Handlers
            {
                get { return this.Values.SelectMany(ex => ex.Values.SelectMany(pr => pr.Values.SelectMany(l => l))); }
            }

            public void Add(GlobalPriority globalPriority, int extensionId, EventPriority priority,
                EventRaiseHandler<T> callback)
            { 
                SortedDictionary<int,
                    SortedDictionary<EventPriority,
                        List<EventRaiseHandler<T>>>> extensions;
                if (!this.TryGetValue(globalPriority, out extensions))
                {
                    extensions =
                        new SortedDictionary<int, SortedDictionary<EventPriority, List<EventRaiseHandler<T>>>>();
                    this.Add(globalPriority, extensions);
                }

                SortedDictionary<EventPriority, List<EventRaiseHandler<T>>> priorities;
                if (!extensions.TryGetValue(extensionId, out priorities))
                {
                    priorities = new SortedDictionary<EventPriority, List<EventRaiseHandler<T>>>();
                    extensions.Add(extensionId, priorities);
                }

                List<EventRaiseHandler<T>> value;
                if (!priorities.TryGetValue(priority, out value))
                {
                    value = new List<EventRaiseHandler<T>>();
                    priorities.Add(priority, value);
                }

                value.Add(callback);
            }

            public bool Remove(EventRaiseHandler<T> callback)
            {
                return this.Values.Any(ex => ex.Values.Any(pr => pr.Values.Any(p => p.Remove(callback))));
            }
        }
    }
}