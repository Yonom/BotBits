namespace BotBits
{
    public class LoginRewardData
    {
        public bool FirstLogin { get; }
        public int LoginStreak { get; }
        public Reward[] Rewards { get; }

        public LoginRewardData(bool firstLogin, int loginStreak, Reward[] rewards)
        {
            this.FirstLogin = firstLogin;
            this.LoginStreak = loginStreak;
            this.Rewards = rewards;
        }
    }
}