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

            var methods = GetMethods(obj.GetType());
            this.LoadEventhandlers(obj, methods);
        }

        public virtual void LoadStatic<TType>()
        {
            var methods = GetStaticMethods(typeof(TType));
            this.LoadEventhandlers(null, methods);
        }

        public virtual void LoadModule(Type type)
        {
            if (!type.IsAbstract || !type.IsSealed) throw new InvalidOperationException("Only static types may be passed to LoadModule!");
            
            var methods = GetStaticMethods(type);
            this.LoadEventhandlers(null, methods);
        }

        public virtual void Unload([NotNull] object obj)
        {
            if (obj is Type)
                throw new InvalidOperationException("Cannot load Types! Did you mean to use UnloadModule?");

            var methods = GetMethods(obj.GetType());
            this.UnloadEventhandlers(obj, methods);
        }

        public virtual void UnloadStatic<TType>()
        {
            var methods = GetStaticMethods(typeof(TType));
            this.UnloadEventhandlers(null, methods);
        }

        public virtual void UnloadModule(Type type)
        {
            if (!type.IsAbstract || !type.IsSealed)
                throw new InvalidOperationException("Only static types may be passed to UnloadModule!");

            var methods = GetStaticMethods(type);
            this.UnloadEventhandlers(null, methods);
        }

        private void LoadEventhandlers(object baseObj, IEnumerable<MethodInfo> methods)
        {
            var eventHandlers = methods.Where(this.ShouldLoad);
            var binders = eventHandlers
                .Select(eventHandler =>
                    this.GetBinder(baseObj, eventHandler))
                .ToArray(); // ToArray to make sure all methods are valid

            // Now bind them all
            foreach (var binder in binders)
                binder();
        }

        private void UnloadEventhandlers(object baseObj, IEnumerable<MethodInfo> methods)
        {
            var eventHandlers = methods.Where(this.ShouldLoad);
            var unbinders = eventHandlers
                .Select(eventHandler =>
                    this.GetUnbinder(baseObj, eventHandler))
                .ToArray(); // ToArray to make sure all methods are valid

            // Now unbind them all
            foreach (var unbinder in unbinders)
                unbinder();
        }

        public static IEnumerable<MethodInfo> GetStaticMethods(Type type)
        {
            return type.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static);
        }

        public static IEnumerable<MethodInfo> GetMethods(Type type)
        {
            IEnumerable<MethodInfo> methods =
                type.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            if (type.BaseType?.BaseType != null)
            {
                methods = methods.Concat(GetMethods(type.BaseType));
            }

            return methods;
        }

        protected abstract bool ShouldLoad(MethodInfo methodInfo);
        protected abstract Action GetBinder(object baseObj, MethodInfo eventHandler);
        protected abstract Action GetUnbinder(object baseObj, MethodInfo eventHandler);
    }
}