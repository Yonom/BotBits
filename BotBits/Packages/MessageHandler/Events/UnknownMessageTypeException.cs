using System;
using System.Runtime.Serialization;

namespace BotBits.Events
{
    [Serializable]
    public class UnknownMessageTypeException : Exception
    {
        public UnknownMessageTypeException()
        {
        }

        public UnknownMessageTypeException(string message)
            : base(message)
        {
        }

        public UnknownMessageTypeException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected UnknownMessageTypeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}