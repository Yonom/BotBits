using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("roomVisible")]
    public sealed class RoomVisibleEvent : ReceiveEvent<RoomVisibleEvent>
    {
        internal RoomVisibleEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.Visible = message.GetBoolean(0);
        }

        public bool Visible { get; set; }
    }
}