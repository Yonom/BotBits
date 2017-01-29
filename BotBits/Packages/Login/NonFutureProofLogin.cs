using PlayerIOClient;

namespace BotBits
{
    public sealed class NonFutureProofLogin : IPlayerIOGame<LoginClient>, ILogin<LoginClient>
    {
        private readonly BotBitsClient _botBitsClient;

        internal NonFutureProofLogin(BotBitsClient botBitsClient)
        {
            this._botBitsClient = botBitsClient;
        }

        public LoginClient WithClient(Client client)
        {
            return new LoginClient(this._botBitsClient, client);
        }

        ILogin<LoginClient> IPlayerIOGame<LoginClient>.Login => this;

        public string GameId => "everybody-edits-su9rn58o40itdbnw69plyw";

        public PlayerIOGame WithGameId(string gameId)
        {
            return new PlayerIOGame(this, gameId);
        }
    }
}
