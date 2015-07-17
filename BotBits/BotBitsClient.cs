using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics;
using System.Threading;
using JetBrains.Annotations;

namespace BotBits
{
    public class BotBitsClient
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly PackageLoader _packageLoader;

        public BotBitsClient() : this(BotServices.GetScheduler())
        {
        }

        internal BotBitsClient(ISchedulerHandle handle)
        {
            this._packageLoader = new PackageLoader(this);
            this.Extensions = new List<Type>();

            DefaultExtension.LoadInto(this, handle);
        }

        public void Dispose()
        {
            this._packageLoader.Dispose();
        }

        [UsedImplicitly]
        internal PackageLoader Packages
        {
            get { return this._packageLoader; }
        }

        internal List<Type> Extensions { get; private set; } 
    }
}