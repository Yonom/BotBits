namespace BotBits
{
    public class ConnectionArgs
    {
        public ConnectionArgs(string connectUserId, string roomId, PlayerData playerData, DatabaseHandle database)
        {
            this.ConnectUserId = connectUserId;
            this.RoomId = roomId;
            this.PlayerData = playerData;
            this.Database = database;
        }

        public ConnectionArgs(DatabaseHandle database)
        {
            this.Database = database;
        }
        
        public PlayerData PlayerData { get; }
        public string ConnectUserId { get; }
        public string RoomId { get; }
        public DatabaseHandle Database { get; }
    }
}