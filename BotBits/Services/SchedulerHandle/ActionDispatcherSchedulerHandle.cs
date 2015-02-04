using System;
using System.Threading;
using System.Threading.Tasks;
using BotBits.Nito.Async;

namespace BotBits
{
    internal sealed class ActionDispatcherSchedulerHandle : ISchedulerHandle
    {
        private readonly ActionDispatcher _dispatcher;

        public ActionDispatcherSchedulerHandle()
        {
            this._dispatcher = ActionDispatcher.Current;
            if (this._dispatcher == null)
                throw new InvalidOperationException("No dispatcher running on the current thread.");

            this.Scheduler = TaskScheduler.FromCurrentSynchronizationContext();
        }

        public void Dispose()
        {
            this._dispatcher.QueueExit();
        }

        public TaskScheduler Scheduler { get; private set; }

        public static ActionDispatcherSchedulerHandle StartOnNewThread()
        {
            ActionDispatcherSchedulerHandle res = null;
            // ReSharper disable once AccessToDisposedClosure
            using (var resetEvent = new ManualResetEvent(false))
            {
                Task.Factory.StartNew(() => BotServices.RunDispatcher(d =>
                {
                    res = new ActionDispatcherSchedulerHandle();
                    resetEvent.Set();
                }), TaskCreationOptions.LongRunning);
                resetEvent.WaitOne();
            }
            return res;
        }
    }
}
