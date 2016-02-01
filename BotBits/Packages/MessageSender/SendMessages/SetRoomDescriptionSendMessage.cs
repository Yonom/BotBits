using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Sent to change world description.
    /// </summary>
    /// <seealso cref="SendMessage{T}" />
    public sealed class SetRoomDescriptionSendMessage : SendMessage<SetRoomDescriptionSendMessage>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SetRoomDescriptionSendMessage" /> class.
        /// </summary>
        /// <param name="description">The description.</param>
        public SetRoomDescriptionSendMessage(string description)
        {
            this.Description = description;
        }

        /// <summary>
        ///     Gets or sets the description.
        /// </summary>
        /// <value>
        ///     The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            return Message.Create("setRoomDescription", this.Description);
        }
    }
}