using System;
using System.Runtime.Serialization;

namespace BotBits
{
    [Serializable]
    public class JoinException : Exception
    {
        public string Title { get; set; }
        public string Reason { get; set; }

        public JoinException(string title, string reason) 
            : base(title + ": " + reason)
        {
            this.Title = title;
            this.Reason = reason;
        }

        public JoinException(string title, string reason, Exception innerException) 
            : base(title + ": " + reason, innerException)
        {
            this.Title = title;
            this.Reason = reason;
        }

        protected JoinException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
