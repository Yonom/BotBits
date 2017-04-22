using System;

namespace BotBits
{
    public struct Reward
    {
        public RewardType RewardType
        {
            get
            {
                RewardType res;
                Enum.TryParse(this.RewardString, out res);
                return res;
            }
        }

        public string RewardString { get; }
        public int Quantity { get; private set; }

        public Reward(string rewardString, int quantity)
            : this()
        {
            this.RewardString = rewardString;
            this.Quantity = quantity;
        }
    }
}