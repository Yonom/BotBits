namespace BotBits.Events
{
    public sealed class PrivateMessageEvent : Event<PrivateMessageEvent>
    {
        internal PrivateMessageEvent(string username, string message)
        {
            this.Username = username;
            this.Message = message;
        }

        public string Username { get; private set; }
        public string Message { get; private set; }
    }
}