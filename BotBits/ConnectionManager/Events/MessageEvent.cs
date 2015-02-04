using PlayerIOClient;

namespace BotBits.Events
{
    public sealed class MessageEvent : Event<MessageEvent>
    {
        internal MessageEvent(Message message)
        {
            this.Message = message;
        }

        public Message Message { get; private set; }
    }
}
