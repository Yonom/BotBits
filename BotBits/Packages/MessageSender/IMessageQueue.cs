namespace BotBits
{
    internal interface IMessageQueue
    {
        void SendTicks(long ticks, long maxTicks, BotBitsClient client);
    }
}