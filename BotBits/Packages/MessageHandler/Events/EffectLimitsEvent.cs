using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("effectlimits")]
    public sealed class EffectLimitsEvent : ReceiveEvent<EffectLimitsEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="EffectLimitsEvent" /> class.
        /// </summary>
        /// <param name="client">The EE message.</param>
        /// <param name="message">The message.</param>
        internal EffectLimitsEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.CurseLimit = message.GetInt(0);
            this.ZombieLimit = message.GetInt(1);
        }

        public int ZombieLimit { get; set; }

        public int CurseLimit { get; set; }
    }
}