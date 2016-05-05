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
                    this._player = Players.Of(client).TryAddPlayer(message.GetInt(userId));
                }
                else
                {
                    Players.Of(client).TryGetPlayer(message.GetInt(userId), out this._player);
                }
            }
            else
            {
                this._player = Player.Nobody;
            }
        }

        public Player Player
        {
            get { return this._player; }
            protected set { this._player = value; }
        }

        public bool Cancelled => this.Player == null;
    }
}