using System.Threading;
using System.Threading.Tasks;

namespace BotBits
{
    public static class EventHandleExtensions
    {
        public static Task<T> WaitOneAsync<T>(
            this EventHandle<T> eventHandle, 
            CancellationToken ct,
            EventPriority priority = default(EventPriority))
            where T : Event<T>
        {
            var tcs = new TaskCompletionSource<T>();
            ct.Register(() =>
                tcs.TrySetCanceled(), false);

            var raiseHandler = new EventRaiseHandler<T>(t => 
                tcs.TrySetResult(t));
            eventHandle.Bind(raiseHandler, priority);
            tcs.Task.ContinueWith(t => 
                eventHandle.Unbind(raiseHandler), CancellationToken.None);

            return tcs.Task;
        }

        public static Task<T> WaitOneAsync<T>(
            this EventHandle<T> eventHandle, 
            EventPriority priority = default(EventPriority))
            where T : Event<T>
        {
            return eventHandle.WaitOneAsync(CancellationToken.None, priority);
        }
    }
}
