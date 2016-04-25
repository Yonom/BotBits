namespace BotBits
{
    public sealed class PlayerIOGame : IPlayerIOGame<LoginClient>
    {
        public PlayerIOGame(ILogin<LoginClient> login, string gameId)
        {
            this.Login = login;
            this.GameId = gameId;
        }

        public string GameId { get; }
        public ILogin<LoginClient> Login { get; }
    }
}