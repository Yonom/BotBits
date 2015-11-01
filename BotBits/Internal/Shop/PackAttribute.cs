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

        public int BlocksPerPack { get; set; }
        public ForegroundType ForegroundType { get; set; }
        public bool BuildersClubOnly { get; set; }
    }
}