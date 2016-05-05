using System;

namespace BotBits.Tests.Packages
{
    internal sealed class TestPackage : Package<TestPackage>, IDisposable
    {
        public bool IsDisposed { get; private set; }

        public new BotBitsClient BotBits => base.BotBits;

        public void Dispose()
        {
            this.IsDisposed = true;
        }
    }
}