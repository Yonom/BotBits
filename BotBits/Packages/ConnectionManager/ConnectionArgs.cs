namespace BotBits
{
    public class ConnectionArgs
    {
        public ConnectionArgs(string connectUserId, string roomId, PlayerData playerData)
        {
            this.ConnectUserId = connectUserId;
            this.RoomId = roomId;
            this.PlayerData = playerData;
        }

        public ConnectionArgs()
        {
        }

        public PlayerData PlayerData { get; private set; }
        public string ConnectUserId { get; private set; }
        public string RoomId { get; private set; }
    }
}