using System;
using System.Collections.Generic;
using PlayerIOClient;

namespace BotBits.Events
{
    public interface IPlayerEvent
    {
        Player Player { get; }
    }

    public abstract class PlayerEvent<T> : ReceiveEvent<T>, IPlayerEvent where T : PlayerEvent<T>
    {
        internal PlayerEvent(BotBitsClient client, Message message, uint userId = 0, bool create = false)
            : base(client, message)
        {
            try
            {
                this.Player = message.Count <= userId
                    ? Player.Nobody
                    : create
                        ? Players.Of(client).AddPlayer(message.GetInt(userId))
                        : Players.Of(client)[message.GetInt(userId)];
            }
            catch (KeyNotFoundException)
            {
                this.Player = null;
            }
            catch (ArgumentException)
            {
                this.Player = null;
            }
        }

        public Player Player { get; private set; }
    }
}
