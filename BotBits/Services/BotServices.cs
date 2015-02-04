using System;
using System.Threading;
using BotBits.Nito.Async;

namespace BotBits
{
    public static class BotServices
    {
        public static void Run(Action<BotBitsClient> callback)
        {
            RunDispatcher(d => callback(new BotBitsClient(new ActionDispatcherSchedulerHandle())));
        }

        internal static ISchedulerHandle GetScheduler()
        {
            // If the current SynchronizationContext is not set, create a new ActionThread
            return SynchronizationContext.Current != null
                ? (ISchedulerHandle)new SynchronizationContextSchedulerHandle()
                : ActionDispatcherSchedulerHandle.StartOnNewThread();
        }

        internal static void RunDispatcher(Action<ActionDispatcher> task)
        {
            var dispatcher = new ActionDispatcher();
            dispatcher.QueueAction(() => task(dispatcher));
            dispatcher.Run();
        }
    }
}
