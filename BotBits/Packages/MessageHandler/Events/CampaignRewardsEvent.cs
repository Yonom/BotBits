using System.Collections.Generic;
using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when receiving rewards for completing campaign world.
    /// </summary>
    /// <seealso cref="PlayerEvent{T}" />
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
            ShowBadge = message.GetBoolean(i++);

            if (ShowBadge)
            {
                BadgeTitle = message.GetString(i++);
                BadgeDescription = message.GetString(i++);
                BadgeImageUrl = message.GetString(i++);
            }
            else
            {
                NextWorldImageUrl = message.GetString(i++);
            }

            Rewards = new List<CampaignReward>();
            for (; i < message.Count;)
            {
                var reward = message.GetString(i++);
                var quantity = message.GetInt(i++);

                Rewards.Add(new CampaignReward(reward, quantity));
            }
        }

        /// <summary>
        ///     Gets or sets the rewards.
        /// </summary>
        /// <value>The rewards.</value>
        public List<CampaignReward> Rewards { get; set; }

        /// <summary>
        ///     Gets or sets the image URL of next world in campaign.
        /// </summary>
        /// <value>The image URL of next world in campaign.</value>
        public string NextWorldImageUrl { get; set; }

        /// <summary>
        ///     Gets or sets the badge image URL.
        /// </summary>
        /// <value>The badge image URL.</value>
        public string BadgeImageUrl { get; set; }

        /// <summary>
        ///     Gets or sets the badge description.
        /// </summary>
        /// <value>The badge description.</value>
        public string BadgeDescription { get; set; }

        /// <summary>
        ///     Gets or sets the badge title.
        /// </summary>
        /// <value>The badge title.</value>
        public string BadgeTitle { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether received badge.
        /// </summary>
        /// <value><c>true</c> if received badge; otherwise, <c>false</c>.</value>
        public bool ShowBadge { get; set; }
    }
}