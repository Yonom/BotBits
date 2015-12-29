using System.Diagnostics;
using System.Threading.Tasks;
using PlayerIOClient;

namespace BotBits
{
    [DebuggerDisplay("{Id}: {Name}")]
    public sealed class LobbyItem
    {
        private readonly ILoginClient _client;

        public LobbyItem(ILoginClient client, RoomInfo roomInfo)
        {
            this._client = client;

            this.Id = roomInfo.Id;
            this.Online = roomInfo.OnlineUsers;
            foreach (var data in roomInfo.RoomData)
            {
                switch (data.Key)
                {
                    case "name":
                        this.Name = data.Value;
                        break;
                    case "plays":
                        this.Plays = int.Parse(data.Value);
                        break;
                    case "Likes":
                        this.Likes = int.Parse(data.Value);
                        break;
                    case "Favorites":
                        this.Favorites = int.Parse(data.Value);
                        break;
                    case "description":
                        this.Description = data.Value;
                        break;
                        
                    case "openworld":
                        this.OpenWorld = bool.Parse(data.Value);
                        break;
                    case "needskey":
                        this.NeedsKey = (data.Value == "yep");
                        break;

                    case "beta":
                        this.Beta = int.Parse(data.Value);
                        break;
                    case "IsFeatured":
                        this.Featured = bool.Parse(data.Value);
                        break;
                    case "IsCampaign":
                        this.Campaign = bool.Parse(data.Value);
                        break;

                    case "LobbyPreviewEnabled":
                        this.LobbyPreviewEnabled = bool.Parse(data.Value);
                        break;
                }
            }
        }

        public bool OpenWorld { get; }
        public bool LobbyPreviewEnabled { get; }
        public string Description { get; }
        public bool Campaign { get; }

        public int Beta { get; }
        public int Online { get; }
        public string Id { get; }
        public string Name { get; }
        public int Plays { get; }
        public int Likes { get; }
        public bool NeedsKey { get; }
        public bool Featured { get; }
        public int Favorites { get; }

        public void JoinRoom()
        {
            this.JoinRoomAsync().Wait();
        }

        public Task JoinRoomAsync()
        {
            return this._client.JoinRoomAsync(this.Id);
        }
    }
}