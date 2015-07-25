using System;
using JetBrains.Annotations;

namespace BotBits
{
    /// <summary>
    ///     Indicates that a function is a handler for a specific event.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method), MeansImplicitUse]
    public sealed class EventListenerAttribute : Attribute
    {
        private readonly EventPriority _priority;
        private readonly GlobalPriority _globalPriority;

        /// <summary>
        ///     Initializes a new instance of the <see cref="EventListenerAttribute" /> class.
        /// </summary>
        public EventListenerAttribute()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EventListenerAttribute" /> class.
        /// </summary>
        /// <param name="priority">The priority of this event handler.</param>
        public EventListenerAttribute(EventPriority priority)
        {
            this._priority = priority;
        }

        public EventListenerAttribute(GlobalPriority globalPriority)
        {
            this._globalPriority = globalPriority;
        }

        public EventListenerAttribute(GlobalPriority globalPriority, EventPriority priority)
            : this(priority)
        {
            this._globalPriority = globalPriority;
        }

        /// <summary>
        ///     Gets the priority of this event handler.
        /// </summary>
        /// <value>
        ///     The priority of this event handler.
        /// </value>
        public EventPriority Priority
        {
            get { return this._priority; }
        }

        public GlobalPriority GlobalPriority
        {
            get { return this._globalPriority; }
        }
    }
}