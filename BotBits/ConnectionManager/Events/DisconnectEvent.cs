namespace BotBits.Events
{
    public sealed class DisconnectEvent : Event<DisconnectEvent>
    {
        internal DisconnectEvent(string message)
        {
            this.Message = message;
        }

        public string Message { get; set; }
    }
}