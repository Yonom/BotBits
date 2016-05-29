using System;
using System.Runtime.Serialization;

namespace BotBits
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

    [Serializable]
    public class UnknownPlayerException : Exception
    {
        public UnknownPlayerException()
        {
        }

        public UnknownPlayerException(string message)
            : base(message)
        {
        }

        public UnknownPlayerException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected UnknownPlayerException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}