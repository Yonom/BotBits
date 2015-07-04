using System.Threading.Tasks;

namespace BotBits
{
    public interface ILoginClient
    {
        Task<LobbyItem[]> GetLobbyAsync();
        Task CreateOpenWorldAsync(string roomId, string name);
        Task CreateJoinRoomAsync(string roomId);
        Task JoinRoomAsync(string roomId);
        Task<DatabaseWorld> LoadWorldAsync(string roomId);
    }
}