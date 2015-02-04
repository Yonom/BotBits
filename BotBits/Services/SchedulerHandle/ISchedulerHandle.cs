using System;
using System.Threading.Tasks;

namespace BotBits
{
    internal interface ISchedulerHandle : IDisposable
    {
        TaskScheduler Scheduler { get; }
    }
}
