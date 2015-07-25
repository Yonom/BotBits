using JetBrains.Annotations;
using PlayerIOClient;

namespace BotBits
{
    public interface IPlayerIOGame<out T>
    {
        string GameId { get; }
        IConnectionManager<T> ConnectionManager { get; }
    }

    public interface IConnectionManager
    {
        void AttachConnection([NotNull] Connection connection, ConnectionArgs args);
        void SetConnection([NotNull] IConnection connection, ConnectionArgs args);
    }

    public interface IConnectionManager<out T> : IConnectionManager
    {
        T WithClient(Client client);
    }
}