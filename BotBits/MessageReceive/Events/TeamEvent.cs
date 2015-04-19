using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("team")]
    public sealed class TeamEvent : PlayerEvent<TeamEvent>
    {
        public TeamEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.Team = (Team)message.GetInt(1);
        }

        public Team Team { get; set; }
    }
}
