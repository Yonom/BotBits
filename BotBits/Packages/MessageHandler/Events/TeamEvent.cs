using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when someone changes their team.
    /// </summary>
    /// <seealso cref="PlayerEvent{T}" />
    [ReceiveEvent("team")]
    public sealed class TeamEvent : PlayerEvent<TeamEvent>
    {
        internal TeamEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.Team = (Team) message.GetInt(1);
        }

        /// <summary>
        ///     Gets or sets the team.
        /// </summary>
        /// <value>The team.</value>
        public Team Team { get; set; }
    }
}