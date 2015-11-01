using System;

namespace BotBits
{
    public struct CampaignReward
    {
        public CampaignRewardType RewardType
        {
            get
            {
                CampaignRewardType res;
                Enum.TryParse(this.Reward, out res);
                return res;
            }
        }

        public string Reward { get; }
        public int Quantity { get; private set; }

        public CampaignReward(string reward, int quantity)
            : this()
        {
            this.Reward = reward;
            this.Quantity = quantity;
        }
    }
}