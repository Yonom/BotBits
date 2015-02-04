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
            var coords = new List<KeyValuePair<int, Point>>();
            this.Coordinates = new List<KeyValuePair<int, Point>>(coords);

            this.ResetCoins = message.GetBoolean(0);

            for (uint i = 1; i <= message.Count - 1u; i += 3)
            {
                coords.Add(new KeyValuePair<int, Point>(message.GetInteger(i),
                    new Point(message.GetInteger(i + 1u), message.GetInteger(i + 2u))));
            }
        }

        /// <summary>
        ///     Gets or sets the coordinates.
        /// </summary>
        /// <value>The coordinates.</value>
        public List<KeyValuePair<int, Point>> Coordinates { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether the coins need to be reset.
        /// </summary>
        /// <value><c>true</c> if the coins need to be reset; otherwise, <c>false</c>.</value>
        public bool ResetCoins { get; set; }
    }
}