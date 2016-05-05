using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;

namespace BotBits
{
    public abstract class LoaderBase<T> : Package<T> where T : LoaderBase<T>, new()
    {
        public virtual void Load([NotNull] object obj)
        {
            if (obj is Type) throw new InvalidOperationException("Cannot load Types! Did you mean to use LoadModule?");

            var methods = Utils.GetMethods(obj.GetType());
            this.LoadEventhandlers(obj, methods);
        }

        public virtual void LoadStatic<TType>()
        {
            var type = typeof(TType);
            var methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
            this.LoadEventhandlers(null, methods);
        }

        public virtual void LoadModule(Type type)
        {
            if (!type.IsAbstract || !type.IsSealed) throw new InvalidOperationException("Only static types may be passed to LoadModule!");

            var methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
            this.LoadEventhandlers(null, methods);
        }

        private void LoadEventhandlers(object baseObj, IEnumerable<MethodInfo> methods)
        {
            var eventHandlers = methods.Where(this.ShouldLoad);
            var binders = eventHandlers
                .Select(eventHandler =>
                    this.GetBinder(baseObj, eventHandler))
                .ToArray(); // ToArray to make sure all methods are valid

            // Now bind them all
            foreach (var binder in binders) binder();
        }

        protected abstract bool ShouldLoad(MethodInfo methodInfo);
        protected abstract Action GetBinder(object baseObj, MethodInfo eventHandler);
    }
}