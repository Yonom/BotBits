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
            this.Priority = priority;
        }

        public EventListenerAttribute(GlobalPriority globalPriority)
        {
            this.GlobalPriority = globalPriority;
        }

        public EventListenerAttribute(GlobalPriority globalPriority, EventPriority priority)
            : this(priority)
        {
            this.GlobalPriority = globalPriority;
        }

        /// <summary>
        ///     Gets the priority of this event handler.
        /// </summary>
        /// <value>
        ///     The priority of this event handler.
        /// </value>
        public EventPriority Priority { get; }

        public GlobalPriority GlobalPriority { get; }
    }
}