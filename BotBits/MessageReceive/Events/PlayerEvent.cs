using PlayerIOClient;

namespace BotBits.Events
{
    public abstract class PlayerEvent<T> : ReceiveEvent<T> where T : PlayerEvent<T>
    {
        internal PlayerEvent(BotBitsClient client, Message message, uint userId = 0)
            : base(client, message)
        {
            this.Player = message.Count <= userId 
                ? Player.Nobody 
                : Players.Of(client).GetOrAddPlayer(message.GetInt(userId));
        }

        public Player Player { get; private set; }
    }
}
