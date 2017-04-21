using System;

namespace BotBits
{
    public class DiagnosticException : Exception
    {
        public DiagnosticException(string message)
            : base(message)
        {
        }
    }
}