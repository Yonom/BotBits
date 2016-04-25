namespace BotBits
{
    public interface IPlayerIOGame<out T>
    {
        string GameId { get; }
        ILogin<T> Login { get; }
    }
}