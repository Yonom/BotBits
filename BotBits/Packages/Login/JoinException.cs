using System;

namespace BotBits
{
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
    }
}
