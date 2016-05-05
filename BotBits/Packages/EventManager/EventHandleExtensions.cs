using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace BotBits
{
    public static class EventHandleExtensions
    {
        private static Task<T> WaitOneAsyncInternal<T>(
            Assembly assembly,
            EventHandle<T> eventHandle,
            CancellationToken ct,
            GlobalPriority globalPriority,
            EventPriority priority = default(EventPriority))
            where T : Event<T>
        {
            var tcs = new TaskCompletionSource<T>();
            ct.Register(() => tcs.TrySetCanceled(), false);

            var raiseHandler = new EventRaiseHandler<T>(t => tcs.TrySetResult(t));
            eventHandle.BindInternal(assembly, raiseHandler, globalPriority, priority);
            tcs.Task.ContinueWith(t => eventHandle.Unbind(raiseHandler), CancellationToken.None);

            return tcs.Task;
        }

        public static Task<T> WaitOneAsync<T>(
            this EventHandle<T> eventHandle,
            CancellationToken ct,
            GlobalPriority globalPriority,
            EventPriority priority = default(EventPriority))
            where T : Event<T>
        {
            return WaitOneAsyncInternal(Assembly.GetCallingAssembly(), eventHandle, ct, globalPriority, priority);
        }

        public static Task<T> WaitOneAsync<T>(
            this EventHandle<T> eventHandle,
            CancellationToken ct,
            EventPriority priority = default(EventPriority))
            where T : Event<T>
        {
            return WaitOneAsyncInternal(Assembly.GetCallingAssembly(), eventHandle, ct, default(GlobalPriority),
                priority);
        }

        public static Task<T> WaitOneAsync<T>(
            this EventHandle<T> eventHandle,
            GlobalPriority globalPriority,
            EventPriority priority = default(EventPriority))
            where T : Event<T>
        {
            return WaitOneAsyncInternal(Assembly.GetCallingAssembly(), eventHandle, CancellationToken.None,
                globalPriority, priority);
        }

        public static Task<T> WaitOneAsync<T>(
            this EventHandle<T> eventHandle,
            EventPriority priority = default(EventPriority))
            where T : Event<T>
        {
            return WaitOneAsyncInternal(Assembly.GetCallingAssembly(), eventHandle, CancellationToken.None,
                default(GlobalPriority), priority);
        }
    }
}