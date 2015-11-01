using System;

namespace BotBits
{
    [AttributeUsage(AttributeTargets.Class)]
    internal sealed class ReceiveEventAttribute : Attribute
    {
        public ReceiveEventAttribute(string type)
        {
            this.Type = type;
        }

        public string Type { get; }
    }
}