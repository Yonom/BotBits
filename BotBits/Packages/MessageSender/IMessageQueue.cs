namespace BotBits
{
    internal interface IMessageQueue
    {
        void SendTicks(int ticks, BotBitsClient client);
    }
}