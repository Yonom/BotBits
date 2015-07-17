namespace BotBits
{
    internal sealed class DefaultExtension : Extension<DefaultExtension>
    {
        protected override void Initialize(BotBitsClient client, object args)
        {
            var handle = (ISchedulerHandle)args;
            ConnectionManager.Of(client).CurrentScheduler.SetScheduler(handle);
        }

        public static bool LoadInto(BotBitsClient client, ISchedulerHandle handle)
        {
            return LoadInto(client, (object)handle);
        }
    }
}
