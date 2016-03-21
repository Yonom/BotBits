using System;

namespace BotBits.Shop
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Class)]
    public sealed class PackAttribute : Attribute
    {
        public PackAttribute(string package)
        {
            this.Package = package;
        }

        public string Package { get; }
        
        public ForegroundType ForegroundType { get; set; }
        public bool GoldMemberOnly { get; set; }
        public bool AdminOnly { get; set; }
    }
}