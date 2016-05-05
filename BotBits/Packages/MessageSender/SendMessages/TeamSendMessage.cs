using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Sent to change team.
    /// </summary>
    /// <seealso cref="SendMessage{T}" />
    public sealed class TeamSendMessage : SendMessage<TeamSendMessage>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TeamSendMessage" /> class.
        /// </summary>
        /// <param name="team">The team.</param>
        /// <param name="y">The y.</param>
        /// <param name="x">The x.</param>
        public TeamSendMessage(Team team, int y, int x)
        {
            this.Team = team;
            this.Y = y;
            this.X = x;
        }

        /// <summary>
        ///     Gets or sets the team.
        /// </summary>
        /// <value>
        ///     The team.
        /// </value>
        public Team Team { get; set; }

        /// <summary>
        ///     Gets or sets the y.
        /// </summary>
        /// <value>
        ///     The y.
        /// </value>
        public int Y { get; set; }

        /// <summary>
        ///     Gets or sets the x.
        /// </summary>
        /// <value>
        ///     The x.
        /// </value>
        public int X { get; set; }

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("team", this.X, this.Y, (int)this.Team);
        }
    }
}