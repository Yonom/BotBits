using PlayerIOClient;

namespace BotBits
{
    public sealed class Login : Package<Login>, IPlayerIOGame<LoginClient>, ILogin<LoginClient>
    {
        public LoginClient WithClient(Client client)
        {
            return new LoginClient(this.BotBits, client);
        }

        ILogin<LoginClient> IPlayerIOGame<LoginClient>.Login => this;

        public string GameId => PlayerIOServices.GameId;

        public PlayerIOGame WithGameId(string gameId)
        {
            return new PlayerIOGame(this, gameId);
        }
    }
}