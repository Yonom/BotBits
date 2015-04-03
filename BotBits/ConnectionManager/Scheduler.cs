using System;
using System.Threading;

namespace BotBits
{
    public sealed class Scheduler : IDisposable
    {
        private ISchedulerHandle _schedulerHandle;

        internal Scheduler()
        {
        }

        public void Schedule(Action task)
        {
            this.InitScheduler(true);
            this._schedulerHandle.SynchronizationContext.Post(o => task(), null);
        }

        public void CaptureScheduler()
        {
            this.SetScheduler(BotServices.GetScheduler());
        }

        internal void SetScheduler(ISchedulerHandle handle)
        {
            var old = Interlocked.Exchange(ref this._schedulerHandle, handle);
            if (old != null)
                old.Dispose();
        }

        internal void InitScheduler(bool create)
        {
            if (this._schedulerHandle == null)
            {
                var scheduler = create
                    ? BotServices.GetOrCreateScheduler()
                    : BotServices.GetScheduler();

                if (!CompareSetScheduler(scheduler))
                    scheduler.Dispose();
            }
        }

        private bool CompareSetScheduler(ISchedulerHandle handle)
        {
            return Interlocked.CompareExchange(ref this._schedulerHandle, handle, null) == null;
        }

        public void Dispose()
        {
            this._schedulerHandle.Dispose();
        }
    }
}