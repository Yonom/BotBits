using System;
using System.Linq;
using System.Threading.Tasks;

namespace BotBits
{
    internal static class TaskExtensions
    {
        public static void WaitEx(this Task task)
        {
            try
            {
                task.Wait();
            }
            catch (AggregateException ex)
            {
                throw ex.InnerExceptions.FirstOrDefault() ?? ex;
            }
        }

        public static T GetResultEx<T>(this Task<T> task)
        {
            try
            {
                return task.Result;
            }
            catch (AggregateException ex)
            {
                var inner = ex.InnerExceptions.FirstOrDefault();
                if (inner == null) throw;
                throw inner;
            }
        }

        public static Task ToSafeTask(this Task task)
        {
            var tcs = new TaskCompletionSource<AsyncVoid>();
            task.ContinueWith(t =>
            {
                if (t.IsFaulted)
                    tcs.TrySetException(t.Exception.Flatten().InnerExceptions.FirstOrDefault() ?? t.Exception);
                else if (t.IsCanceled) tcs.TrySetCanceled();
                else tcs.TrySetResult(default(AsyncVoid));
            });
            return tcs.Task;
        }

        public static Task<T> ToSafeTask<T>(this Task<T> task)
        {
            var tcs = new TaskCompletionSource<T>();
            task.ContinueWith(t =>
            {
                if (t.IsFaulted)
                    tcs.TrySetException(t.Exception.Flatten().InnerExceptions.FirstOrDefault() ?? t.Exception);
                else if (t.IsCanceled) tcs.TrySetCanceled();
                else tcs.TrySetResult(t.Result);
            });
            return tcs.Task;
        }
    }
}