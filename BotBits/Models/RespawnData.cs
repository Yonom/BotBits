namespace BotBits
{
    public class RespawnData
    {
        public Player Player { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Deaths { get; set; }

        public RespawnData(Player player, int x, int y, int deaths)
        {
            this.Player = player;
            this.X = x;
            this.Y = y;
            this.Deaths = deaths;
        }
    }
}
