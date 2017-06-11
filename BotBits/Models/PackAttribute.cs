using System;

namespace BotBits
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Class)]
    public sealed class PackAttribute : Attribute
    {
        public PackAttribute()
        {
        }

        public PackAttribute(string package)
        {
            this.Package = package;
        }

        public string Package { get; }

        public ForegroundType ForegroundType { get; set; }
        public bool GoldMembershipItem { get; set; }
        public bool AdminOnly { get; set; }
    }
}