using System.Threading.Tasks;

namespace BotBits
{
    internal sealed class SynchronizationContextSchedulerHandle : ISchedulerHandle
    {
        public SynchronizationContextSchedulerHandle()
        {
            this.Scheduler = TaskScheduler.FromCurrentSynchronizationContext();
        }

        public void Dispose()
        {
        }

        public TaskScheduler Scheduler { get; private set; }
    }
}
