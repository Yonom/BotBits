using System.Threading;
using System.Threading.Tasks;

namespace BotBits
{
    public interface ILoginClient
    {
        Task<LobbyItem[]> GetLobbyAsync();
        Task CreateOpenWorldAsync(string roomId, string name, CancellationToken ct);
        Task CreateJoinRoomAsync(string roomId, CancellationToken ct);
        Task JoinRoomAsync(string roomId, CancellationToken ct);
    }
}