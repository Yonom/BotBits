using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BotBits
{
    public sealed class PlayerIOGame : IPlayerIOGame<LoginClient>
    {
        public PlayerIOGame(IConnectionManager<LoginClient> connectionManager, string gameId)
        {
            this.ConnectionManager = connectionManager;
            this.GameId = gameId;
        }

        public string GameId { get; private set; }
        public IConnectionManager<LoginClient> ConnectionManager { get; private set; }
    }
}
