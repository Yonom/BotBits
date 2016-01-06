using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when effect limits are changed.
    /// </summary>
    /// <seealso cref="ReceiveEvent{T}" />
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
            CurseLimit = message.GetInt(0);
            ZombieLimit = message.GetInt(1);
        }

        /// <summary>
        ///     Gets or sets the zombie limit.
        /// </summary>
        /// <value>The zombie limit.</value>
        public int ZombieLimit { get; set; }

        /// <summary>
        ///     Gets or sets the curse limit.
        /// </summary>
        /// <value>The curse limit.</value>
        public int CurseLimit { get; set; }
    }
}