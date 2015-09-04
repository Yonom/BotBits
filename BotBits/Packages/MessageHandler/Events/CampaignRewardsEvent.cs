using System.Collections.Generic;
using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("campaignRewards")]
    public sealed class CampaignRewardsEvent : ReceiveEvent<CampaignRewardsEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CampaignRewardsEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal CampaignRewardsEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            var i = 0u;
            this.ShowBadge = message.GetBoolean(i++);

            if (this.ShowBadge)
            {
                this.BadgeTitle = message.GetString(i++);
                this.BadgeDescription = message.GetString(i++);
                this.BadgeImageUrl = message.GetString(i++);
            }
            else
            {
                this.NextWorldImageUrl = message.GetString(i++);
            }

            this.Rewards = new List<CampaignReward>();
            for (; i < message.Count;)
            {
                var reward = message.GetString(i++);
                var quantity = message.GetInt(i++);

                this.Rewards.Add(new CampaignReward(reward, quantity));
            }
        }

        public List<CampaignReward> Rewards { get; set; }

        public string NextWorldImageUrl { get; set; }

        public string BadgeImageUrl { get; set; }

        public string BadgeDescription { get; set; }

        public string BadgeTitle { get; set; }

        public bool ShowBadge { get; set; }
    }
}