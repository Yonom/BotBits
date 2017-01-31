using System;

namespace BotBits
{
    internal sealed class DefaultExtension : Extension<DefaultExtension>
    {
        [Obsolete("Invalid to use \"new\" on this class. Use the static LoadInto method instead.", true)]
        public DefaultExtension()
        {
        }

        protected override void Initialize(BotBitsClient client, object args)
        {
            var handle = (ISchedulerHandle)args;
            Scheduler.Of(client).SetScheduler(handle);
        }

        public static bool LoadInto(BotBitsClient client, ISchedulerHandle handle)
        {
            return LoadInto(client, (object)handle);
        }
    }
}