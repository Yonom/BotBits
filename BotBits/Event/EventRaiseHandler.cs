namespace BotBits
{
    public delegate void EventRaiseHandler<in T>(T e) where T : Event<T>;
}