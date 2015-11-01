namespace BotBits
{
    public class RespawnData
    {
        public RespawnData(Player player, int x, int y, int deaths)
        {
            this.Player = player;
            this.X = x;
            this.Y = y;
            this.Deaths = deaths;
        }

        public Player Player { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Deaths { get; set; }
    }
}