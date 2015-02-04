using System;

namespace BotBits.Tests.Packages
{
    internal sealed class TestPackage : Package<TestPackage>, IDisposable
    {
        public bool IsDisposed { get; private set; }

        public new BotBitsClient BotBits
        {
            get { return base.BotBits; }
        }

        public void Dispose()
        {
            this.IsDisposed = true;
        }
    }
}