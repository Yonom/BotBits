using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;

namespace BotBits
{
    public sealed class EventLoader : Package<EventLoader>
    {
        private static readonly MethodInfo _bindMethod =
            typeof(EventLoader).GetMethod("Bind", BindingFlags.NonPublic | BindingFlags.Instance);

        [Obsolete("Invalid to use \"new\" on this class. Use the static .Of(botBits) method instead.", true)]
        public EventLoader()
        {
        }

        public void Load([NotNull]object obj)
        {
            MethodInfo[] methods =
                obj.GetType().GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            this.LoadEventhandlers(obj.GetType(), obj, methods);
        }

        [Obsolete("The method Load(obj) cannot be used with typeof(T). Did you mean: EventLoader.Load(this)", true)]
        public void Load(Type type)
        {
            throw new NotSupportedException("Type objects cannot be loaded.");
        }

        public void LoadStatic(Type type)
        {
            MethodInfo[] methods =
                type.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
            this.LoadEventhandlers(type, null, methods);
        }

        private void LoadEventhandlers(Type type, object baseObj, IEnumerable<MethodInfo> methods)
        {
            var eventHandlers =
                methods.Where(prop => 
                    prop.IsDefined(typeof(EventListenerAttribute), true));
            var binders = eventHandlers
                .Select(eventHandler =>
                    this.LoadEventHandler(type, baseObj, eventHandler))
                .ToArray(); // ToArray to make sure all methods are valid

            // Now bind them all
            foreach (var binder in binders)
                binder();
        }

        private Action LoadEventHandler(Type type, object baseObj, MethodInfo eventHandler)
        {
            ParameterInfo[] parameters = eventHandler.GetParameters();
            if (parameters.Length != 1)
                throw GetEventEx(type, eventHandler.Name, "EventListeners must have one argument of type Event.");

            Type e = parameters[0].ParameterType;
            if (!Utils.IsEvent(e))
                throw GetEventEx(type, eventHandler.Name, "The argument must be an event.");

            MethodInfo genericBind = _bindMethod.MakeGenericMethod(e);
            return () => genericBind.Invoke(this, new[] {baseObj, eventHandler});
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
                .Bind(handler, attribute.Priority);
        }

        private static Exception GetEventEx(Type type, string name, string reason)
        {
            
            return
                new TypeLoadException(String.Format("Unable to assign the method {0}.{1} to an event listener. {2}",
                    type.FullName, name, reason));
        }
    }
}