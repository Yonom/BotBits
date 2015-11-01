using System;
using System.Threading;

namespace BotBits
{
    internal interface ISchedulerHandle : IDisposable
    {
        SynchronizationContext SynchronizationContext { get; }
    }
}