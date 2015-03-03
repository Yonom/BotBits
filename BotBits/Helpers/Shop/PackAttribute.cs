using System;
using System.Threading;

namespace BotBits.Shop
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Class)]
    internal sealed class PackAttribute : Attribute
    {
        private readonly string _package;

        public string Package
        {
            get { return this._package; }
        }

        public int BlocksPerPack { get; set; }

        public PackAttribute(string package)
        {
            this._package = package;
        }
    }
}
