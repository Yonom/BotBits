using System;
using System.Threading;

namespace BotBits
{
    public sealed class Scheduler : Package<Scheduler>, IDisposable
    {
        private ISchedulerHandle _schedulerHandle;

        [Obsolete("Invalid to use \"new\" on this class. Use the static .Of(BotBits) method instead.", true)]
        public Scheduler()
        {
        }

        public void Dispose()
        {
            this._schedulerHandle?.Dispose();
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
            old?.Dispose();
        }

        internal void InitScheduler(bool create)
        {
            if (this._schedulerHandle == null)
            {
                var scheduler = create
                    ? BotServices.GetOrCreateScheduler()
                    : BotServices.GetScheduler();

                if (!this.CompareSetScheduler(scheduler)) scheduler.Dispose();
            }
        }

        private bool CompareSetScheduler(ISchedulerHandle handle)
        {
            return Interlocked.CompareExchange(ref this._schedulerHandle, handle, null) == null;
        }
    }
}