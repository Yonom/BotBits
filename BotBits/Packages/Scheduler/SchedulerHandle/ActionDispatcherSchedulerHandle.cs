using System;
using System.Threading;
using BotBits.Nito.Async;

namespace BotBits
{
    internal sealed class ActionDispatcherSchedulerHandle : ISchedulerHandle
    {
        private readonly ActionDispatcher _dispatcher;

        public ActionDispatcherSchedulerHandle()
        {
            this._dispatcher = ActionDispatcher.Current;
            if (this._dispatcher == null) throw new InvalidOperationException("No dispatcher running on the current thread.");

            this.SynchronizationContext = SynchronizationContext.Current;
        }

        public void Dispose()
        {
            this._dispatcher.QueueExit();
        }

        public SynchronizationContext SynchronizationContext { get; }

        public static ActionDispatcherSchedulerHandle StartOnNewThread()
        {
            ActionDispatcherSchedulerHandle res = null;
            // ReSharper disable once AccessToDisposedClosure
            using (var resetEvent = new ManualResetEvent(false))
            {
                new Thread(o => BotServices.RunDispatcher(d =>
                {
                    res = new ActionDispatcherSchedulerHandle();
                    resetEvent.Set();
                })) { IsBackground = true }.Start();
                resetEvent.WaitOne();
            }
            return res;
        }
    }
}