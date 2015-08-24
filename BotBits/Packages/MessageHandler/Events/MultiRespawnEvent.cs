using System.Collections.Generic;
using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when mutliple players are teleported. This event gets raised for respawns of any kind, including death.
    /// </summary>
    [ReceiveEvent("tele")]
    public sealed class MultiRespawnEvent : ReceiveEvent<MultiRespawnEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MultiRespawnEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal MultiRespawnEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.Coordinates = new List<PlayerPoint>();

            this.ResetCoins = message.GetBoolean(0);

            for (uint i = 1; i <= message.Count - 1u; i += 3)
            {
                var userId = message.GetInteger(i);
                if (!Players.Of(client).Contains(userId)) continue;
                var player = Players.Of(client)[userId];
                var x = message.GetInteger(i + 1u);
                var y =  message.GetInteger(i + 2u);

                this.Coordinates.Add(new PlayerPoint(player, x, y));
            }
        }

        /// <summary>
        ///     Gets or sets the coordinates.
        /// </summary>
        /// <value>The coordinates.</value>
        public List<PlayerPoint> Coordinates { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the coins need to be reset.
        /// </summary>
        /// <value><c>true</c> if the coins need to be reset; otherwise, <c>false</c>.</value>
        public bool ResetCoins { get; set; }
    }
}