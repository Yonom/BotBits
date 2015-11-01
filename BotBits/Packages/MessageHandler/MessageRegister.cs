using System;
using System.Collections.Concurrent;

namespace BotBits
{
    internal sealed class MessageRegister
    {
        private readonly ConcurrentDictionary<string, Type> _messageDictionary =
            new ConcurrentDictionary<string, Type>();

        public bool TryGetHandler(string str, out Type message)
        {
            return this._messageDictionary.TryGetValue(str, out message);
        }

        public bool RegisterMessage(string str, Type type)
        {
            return this._messageDictionary.TryAdd(str, type);
        }
    }
}