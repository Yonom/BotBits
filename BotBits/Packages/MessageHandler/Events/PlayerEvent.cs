using PlayerIOClient;

namespace BotBits.Events
{
    internal interface ICancellable
    {
        bool Cancelled { get; }
    }

    /// <summary>
    ///     Base for the player events. Used when message is about specific player.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="BotBits.Events.ReceiveEvent{T}" />
    /// <seealso cref="BotBits.Events.ICancellable" />
    public abstract class PlayerEvent<T> : ReceiveEvent<T>, ICancellable where T : PlayerEvent<T>
    {
        private Player _player;

        internal PlayerEvent(BotBitsClient client, Message message, uint userId = 0, bool create = false)
            : base(client, message)
        {
            if (message.Count > userId)
            {
                if (create)
                {
                    _player = Players.Of(client).TryAddPlayer(message.GetInt(userId));
                }
                else
                {
                    Players.Of(client).TryGetPlayer(message.GetInt(userId), out _player);
                }
            }
            else
            {
                _player = Player.Nobody;
            }
        }

        public Player Player
        {
            get { return _player; }
            protected set { _player = value; }
        }

        public bool Cancelled
        {
            get { return Player == null; }
        }
    }
}