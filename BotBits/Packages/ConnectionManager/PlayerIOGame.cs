namespace BotBits
{
    public sealed class PlayerIOGame : IPlayerIOGame<LoginClient>
    {
        public PlayerIOGame(IConnectionManager<LoginClient> connectionManager, string gameId)
        {
            this.ConnectionManager = connectionManager;
            this.GameId = gameId;
        }

        public string GameId { get; }
        public IConnectionManager<LoginClient> ConnectionManager { get; }
    }
}