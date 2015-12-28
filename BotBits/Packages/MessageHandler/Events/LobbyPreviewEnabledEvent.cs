using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("lobbyPreviewEnabled")]
    public sealed class LobbyPreviewEnabledEvent : ReceiveEvent<MinimapEnabledEvent>
    {
        internal LobbyPreviewEnabledEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.Enabled = message.GetBoolean(0);
        }

        public bool Enabled { get; set; }
    }
}