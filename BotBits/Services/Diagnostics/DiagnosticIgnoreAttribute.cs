using System;

namespace BotBits
{
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class DiagnosticIgnoreAttribute : Attribute
    {
    }
}
