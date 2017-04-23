using System.Threading;
using System.Threading.Tasks;

namespace BotBits
{
    public interface ILoginClient
    {
        Task<PlayerData> GetPlayerDataAsync();
        Task<LobbyItem[]> GetLobbyRoomsAsync();
        Task CreateJoinOpenWorldAsync(string roomId, string name, CancellationToken ct);
        Task CreateJoinRoomAsync(string roomId, CancellationToken ct);
        Task JoinRoomAsync(string roomId, CancellationToken ct);
    }
}