using PlayerIOClient;

namespace BotBits
{
    public sealed class Login : Package<Login>, IPlayerIOGame<LoginClient>, ILogin<LoginClient>
    {
        public LoginClient WithClient(Client client)
        {
            return new FutureProofLoginClient(this.BotBits, client);
        }

        ILogin<LoginClient> IPlayerIOGame<LoginClient>.Login => this;

        public string GameId => "everybody-edits-su9rn58o40itdbnw69plyw";

        public PlayerIOGame WithGameId(string gameId)
        {
            return new PlayerIOGame(this, gameId);
        }

        public NonFutureProofLogin WithoutFutureProof()
        {
            return new NonFutureProofLogin(this.BotBits);
        }
    }
}