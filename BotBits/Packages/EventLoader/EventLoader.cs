using System;
using System.Reflection;
using JetBrains.Annotations;

namespace BotBits
{
    public sealed class EventLoader : LoaderBase<EventLoader>
    {
        private static readonly MethodInfo _bindMethod =
            typeof(EventLoader).GetMethod("Bind", BindingFlags.NonPublic | BindingFlags.Instance);

        [Obsolete("Invalid to use \"new\" on this class. Use the static .Of(BotBits) method instead.", true)]
        public EventLoader()
        {
        }

        public override void Load(object obj)
        {
            Scheduler.Of(this.BotBits).InitScheduler(false);
            base.Load(obj);
        }

        protected override bool ShouldLoad(MethodInfo methodInfo)
        {
            return methodInfo.IsDefined(typeof(EventListenerAttribute), true);
        }

        protected override Action GetBinder(object baseObj, MethodInfo eventHandler)
        {
            var parameters = eventHandler.GetParameters();
            if (parameters.Length != 1) throw GetEventEx(eventHandler, "EventListeners must have one argument of type Event.");

            var e = parameters[0].ParameterType;
            if (!Utils.IsEvent(e)) throw GetEventEx(eventHandler, "The argument must be an event.");

            var genericBind = _bindMethod.MakeGenericMethod(e);
            return () => genericBind.Invoke(this, new[] { baseObj, eventHandler });
        }

        [UsedImplicitly]
        private void Bind<TEvent>(object baseObj, MethodInfo eventHandler)
            where TEvent : Event<TEvent>
        {
            var attribute =
                (EventListenerAttribute)
                    eventHandler.GetCustomAttributes(typeof(EventListenerAttribute), true)[0];

            var handler =
                (EventRaiseHandler<TEvent>)
                    Delegate.CreateDelegate(typeof(EventRaiseHandler<TEvent>), baseObj, eventHandler);

            Event<TEvent>
                .Of(this.BotBits)
                .Bind(handler, attribute.GlobalPriority, attribute.Priority);
        }

        private static Exception GetEventEx(MethodInfo handler, string reason)
        {
            return new TypeLoadException($"Unable to assign the method {handler.DeclaringType?.FullName}.{handler.Name} to an event listener. {reason}");
        }
    }
}