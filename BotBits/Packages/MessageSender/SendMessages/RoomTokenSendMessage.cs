namespace BotBits.SendMessages
{
    /// <summary>
    ///     Interface Encrypted Send Event
    /// </summary>
    public abstract class RoomTokenSendMessage<T> : SendMessage<T> where T : RoomTokenSendMessage<T>
    {
        internal RoomTokenSendMessage()
        {
        }

        /// <summary>
        ///     Gets or sets the encryption string.
        /// </summary>
        /// <value>
        ///     The encryption string.
        /// </value>
        protected string RoomToken { get; private set; }

        public override void SendIn(BotBitsClient client)
        {
            this.RoomToken = Room.Of(client).Token;

            base.SendIn(client);
        }
    }
}