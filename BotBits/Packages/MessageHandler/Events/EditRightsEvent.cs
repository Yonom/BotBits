using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("editRights")]
    public sealed class EditRightsEvent : PlayerEvent<EditRightsEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="EditRightsEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal EditRightsEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.AllowEdit = message.GetBoolean(1);
        }

        public bool AllowEdit { get; set; }
    }
}