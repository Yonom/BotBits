using PlayerIOClient;

namespace BotBits
{
    public interface ILogin<out T>
    {
        T WithClient(Client client);
    }
}