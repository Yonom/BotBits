namespace BotBits
{
    public sealed class PlayerIOGame : IPlayerIOGame<LoginClient>
    {
        public PlayerIOGame(ILogin<LoginClient> connectionManager, string gameId)
        {
            this.ConnectionManager = connectionManager;
            this.GameId = gameId;
        }

        public string GameId { get; }
        public ILogin<LoginClient> ConnectionManager { get; }
    }
}