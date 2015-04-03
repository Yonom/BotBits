using System.Threading.Tasks;

namespace BotBits
{
    public interface ILoginClient
    {
        Task<LobbyItem[]> GetLobbyAsync();
        Task CreateJoinRoomAsync(string roomId);
        Task JoinRoomAsync(string roomId);
    }
}