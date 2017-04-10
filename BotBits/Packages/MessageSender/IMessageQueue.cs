namespace BotBits
{
    internal interface IMessageQueue
    {
        void SendTicks(long ticks, BotBitsClient client);
    }
}