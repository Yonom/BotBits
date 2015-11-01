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

        internal static ISchedulerHandle GetOrCreateScheduler()
        {
            // If the current SynchronizationContext is not set, create a new ActionThread
            return GetScheduler() ?? ActionDispatcherSchedulerHandle.StartOnNewThread();
        }

        internal static ISchedulerHandle GetScheduler()
        {
            return SynchronizationContext.Current != null
                ? new SynchronizationContextSchedulerHandle()
                : null;
        }

        internal static void RunDispatcher(Action<ActionDispatcher> task)
        {
            var dispatcher = new ActionDispatcher();
            dispatcher.QueueAction(() => task(dispatcher));
            dispatcher.Run();
        }
    }
}