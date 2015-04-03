using JetBrains.Annotations;
using PlayerIOClient;

namespace BotBits
{
    public interface IConnectionManager<out T>
    {
        void AttachConnection([NotNull] Connection connection, ConnectionArgs args);
        void SetConnection([NotNull] IConnection connection, ConnectionArgs args);
        T WithClient(Client client);
    }
}