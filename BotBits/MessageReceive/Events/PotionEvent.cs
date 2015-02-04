using System;
using System.Threading;
using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("p")]
    public sealed class PotionEvent : PlayerEvent<PotionEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PotionEvent" /> class.
        /// </summary>
        /// <param name="message">The EE message.</param>
        /// <param name="client"></param>
        internal PotionEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.Potion = (Potion)message.GetInteger(1);
            this.Enabled = message.GetBoolean(2);
            this.Timeout = TimeSpan.FromSeconds(message.GetInteger(3));
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this player used a potion.
        /// </summary>
        /// <value><c>true</c> if enabled; otherwise, <c>false</c>.</value>
        public bool Enabled { get; set; }

        /// <summary>
        ///     Gets or sets the potion.
        /// </summary>
        /// <value>The potion.</value>
        public Potion Potion { get; set; }

        /// <summary>
        ///     Gets or sets the timeout.
        /// </summary>
        /// <value>The timeout.</value>
        public TimeSpan Timeout { get; set; }
    }
}