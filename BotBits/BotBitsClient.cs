using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using BotBits.Events;
using JetBrains.Annotations;

namespace BotBits
{
    public class BotBitsClient
    {
        [DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly PackageLoader _packageLoader;

        private int _disposed;

        public BotBitsClient() : this(BotServices.GetScheduler())
        {
        }

        internal BotBitsClient(ISchedulerHandle handle)
        {
            this._packageLoader = new PackageLoader(this);
            this.Extensions = new List<Type>();

            DefaultExtension.LoadInto(this, handle);
            Scheduler.Of(this).InitScheduler(false);
        }

        [UsedImplicitly]
        internal PackageLoader Packages
        {
            get { return this._packageLoader; }
        }

        internal List<Type> Extensions { get; private set; }

        public void Dispose()
        {
            if (Interlocked.Exchange(ref this._disposed, 1) == 0)
            {
                new DisposingEvent().RaiseIn(this);
                this._packageLoader.Dispose();
                new DisposedEvent().RaiseIn(this);
            }
        }
    }
}