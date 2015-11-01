namespace BotBits
{
    public interface IEvent
    {
        void RaiseIn(BotBitsClient client);
    }
}