using System;
using System.Threading;
using System.Threading.Tasks;

namespace BotBits
{
    internal static class WaitHandleExtensions
    {
        public static Task AsTask(this WaitHandle handle)
        {
            return AsTask(handle, TimeSpan.FromMilliseconds(-1));
        }

        public static Task AsTask(this WaitHandle handle, TimeSpan timeout)
        {
            var tcs = new TaskCompletionSource<object>();
            var registration = ThreadPool.RegisterWaitForSingleObject(handle, (state, timedOut) =>
            {
                var localTcs = (TaskCompletionSource<object>)state;
                if (timedOut)
                    localTcs.TrySetCanceled();
                else
                    localTcs.TrySetResult(null);
            }, tcs, timeout,  true);
            tcs.Task.ContinueWith(t =>
            {
                registration.Unregister(null);
            }, TaskScheduler.Default);
            return tcs.Task;
        }
    }
}
