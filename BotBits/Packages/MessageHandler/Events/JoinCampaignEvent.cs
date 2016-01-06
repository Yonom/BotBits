using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when player joins campaign world.
    ///     Contains information about campaign data of the world.
    /// </summary>
    /// <seealso cref="ReceiveEvent{T}" />
    [ReceiveEvent("joinCampaign")]
    public sealed class JoinCampaignEvent : ReceiveEvent<JoinCampaignEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="JoinCampaignEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal JoinCampaignEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            Campaign = message.GetString(0);
            Status = (CampaignStatus) message.GetInt(1);

            if (Status != CampaignStatus.Locked)
            {
                Difficulty = (CampaignDifficulty) message.GetInt(2);
                Tier = message.GetInt(3);
                MaxTiers = message.GetInt(4);
            }
        }

        /// <summary>
        ///     Gets or sets the number of tiers in the campaign.
        /// </summary>
        /// <value>The maximum tiers.</value>
        public int MaxTiers { get; set; }

        /// <summary>
        ///     Gets or sets the tier of the world.
        /// </summary>
        /// <value>The tier.</value>
        public int Tier { get; set; }

        /// <summary>
        ///     Gets or sets the difficulty of the world.
        /// </summary>
        /// <value>The difficulty.</value>
        public CampaignDifficulty Difficulty { get; set; }

        /// <summary>
        ///     Gets or sets the campaign status of the world.
        /// </summary>
        /// <value>The status.</value>
        public CampaignStatus Status { get; set; }

        /// <summary>
        ///     Gets or sets the campaign name.
        /// </summary>
        /// <value>The campaign name.</value>
        public string Campaign { get; set; }
    }
}