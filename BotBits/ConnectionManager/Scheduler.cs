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

        internal void InitScheduler()
        {
            if (this._schedulerHandle == null)
            {
                var scheduler = BotServices.GetScheduler();
                if (Interlocked.CompareExchange(ref this._schedulerHandle, scheduler, null) != null)
                {
                    scheduler.Dispose();
                }
            }
        }

        public void Dispose()
        {
            this._schedulerHandle.Dispose();
        }
    }
}