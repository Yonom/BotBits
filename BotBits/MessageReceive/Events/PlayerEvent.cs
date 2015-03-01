using PlayerIOClient;

namespace BotBits.Events
{
    public abstract class PlayerEvent<T> : ReceiveEvent<T> where T : PlayerEvent<T>
    {
        internal PlayerEvent(BotBitsClient client, Message message, uint userId = 0, bool create = false)
            : base(client, message)
        {
            this.Player = message.Count <= userId
                ? Player.Nobody
                : create
                    ? Players.Of(client).AddPlayer(message.GetInt(userId))
                    : Players.Of(client)[message.GetInt(userId)];
        }

        public Player Player { get; private set; }
    }
}
