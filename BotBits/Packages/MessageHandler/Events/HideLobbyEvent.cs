using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("hideLobby")]
    public sealed class HideLobbyEvent : ReceiveEvent<HideLobbyEvent>
    {
        internal HideLobbyEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.Hidden = message.GetBoolean(0);
        }

        public bool Hidden { get; set; }
    }
}