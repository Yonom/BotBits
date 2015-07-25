using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("roomDescription")]
    public sealed class RoomDescriptionEvent : ReceiveEvent<RoomDescriptionEvent>
    {
        internal RoomDescriptionEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.Description = message.GetString(0);
        }

        public string Description { get; set; }
    }
}