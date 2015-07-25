using System;

namespace BotBits
{
    [AttributeUsage(AttributeTargets.Class)]
    internal sealed class ReceiveEventAttribute : Attribute
    {
        private readonly string _type;

        public string Type
        {
            get { return this._type; }
        }

        public ReceiveEventAttribute(string type)
        {
            this._type = type;
        }
    }
}
