using PlayerIOClient;

namespace BotBits
{
    public sealed class Login : Package<Login>, IPlayerIOGame<LoginClient>, ILogin<LoginClient>
    {
        public LoginClient WithClient(Client client)
        {
            return new LoginClient(ConnectionManager.Of(this.BotBits), client);
        }

        ILogin<LoginClient> IPlayerIOGame<LoginClient>.ConnectionManager
        {
            get { return this; }
        }

        public string GameId
        {
            get { return "everybody-edits-su9rn58o40itdbnw69plyw"; }
        }

        public PlayerIOGame WithGameId(string gameId)
        {
            return new PlayerIOGame(this, gameId);
        }
    }
}
