using PlayerIOClient;

namespace BotBits.Events
{
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
            this.Campaign = message.GetString(0);
            this.Status = (CampaignStatus) message.GetInt(1);

            if (this.Status != CampaignStatus.Locked)
            {
                this.Difficulty = (CampaignDifficulty) message.GetInt(2);
                this.Tier = message.GetInt(3);
                this.MaxTiers = message.GetInt(4);
            }
        }

        public int MaxTiers { get; set; }

        public int Tier { get; set; }

        public CampaignDifficulty Difficulty { get; set; }

        public CampaignStatus Status { get; set; }

        public string Campaign { get; set; }
    }
}