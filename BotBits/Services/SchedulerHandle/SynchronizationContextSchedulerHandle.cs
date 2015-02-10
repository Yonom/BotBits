using System.Threading;
using System.Threading.Tasks;

namespace BotBits
{
    internal sealed class SynchronizationContextSchedulerHandle : ISchedulerHandle
    {
        public SynchronizationContextSchedulerHandle()
        {
            this.SynchronizationContext = SynchronizationContext.Current;
        }

        public void Dispose()
        {
        }

        public SynchronizationContext SynchronizationContext { get; private set; }
    }
}
