using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when completing a world by touching win trophy.
    ///     NOTE: If player received campaign rewards,
    ///     <see cref="CampaignRewardsEvent" /> is received instead of this event.
    /// </summary>
    /// <seealso cref="ReceiveEvent{T}" />
    [ReceiveEvent("completedLevel")]
    public sealed class CompletedLevelEvent : ReceiveEvent<CompletedLevelEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CompletedLevelEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal CompletedLevelEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
        }
    }
}