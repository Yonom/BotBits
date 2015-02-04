using System;
using System.Collections.Generic;
using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("allowpotions")]
    public sealed class AllowPotionsEvent : ReceiveEvent<AllowPotionsEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AllowPotionsEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal AllowPotionsEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.Allowed = message.GetBoolean(0);

            var potsList = new List<Potion>();
            for (uint i = 1; i <= message.Count - 1; i += 1)
            {
                potsList.Add((Potion)Int32.Parse(message.GetString(i)));
            }
            this.DisabledPotions = potsList.ToArray();
        }

        /// <summary>
        ///     Gets or sets a value indicating whether this <see cref="AllowPotionsEvent" /> potions are allowed.
        /// </summary>
        /// <value><c>true</c> if potions are allowed; otherwise, <c>false</c>.</value>
        public bool Allowed { get; set; }

        /// <summary>
        ///     Gets or sets whether potions are disabled.
        /// </summary>
        /// <value>The disabled potions.</value>
        public Potion[] DisabledPotions { get; set; }
    }
}