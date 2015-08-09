using System;
using System.Threading;
using System.Threading.Tasks;

namespace BotBits
{
    internal interface ISchedulerHandle : IDisposable
    {
        SynchronizationContext SynchronizationContext { get; }
    }
}
