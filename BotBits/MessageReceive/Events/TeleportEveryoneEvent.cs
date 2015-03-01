using System.Collections.Generic;
using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when mutliple players are teleported. This event gets raised for respawns of any kind, including death.
    /// </summary>
    [ReceiveEvent("tele")]
    public sealed class TeleportEveryoneEvent : ReceiveEvent<TeleportEveryoneEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TeleportEveryoneEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal TeleportEveryoneEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.Coordinates = new List<KeyValuePair<Player, Point>>();

            this.ResetCoins = message.GetBoolean(0);

            for (uint i = 1; i <= message.Count - 1u; i += 3)
            {
                var player = Players.Of(client)[message.GetInteger(i)];
                var x = message.GetInteger(i + 1u);
                var y =  message.GetInteger(i + 2u);

                this.Coordinates.Add(new KeyValuePair<Player, Point>(player, new Point(x, y)));
            }
        }

        /// <summary>
        ///     Gets or sets the coordinates.
        /// </summary>
        /// <value>The coordinates.</value>
        public List<KeyValuePair<Player, Point>> Coordinates { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the coins need to be reset.
        /// </summary>
        /// <value><c>true</c> if the coins need to be reset; otherwise, <c>false</c>.</value>
        public bool ResetCoins { get; set; }
    }
}