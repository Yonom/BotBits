using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Diagnostics;
using JetBrains.Annotations;

namespace BotBits
{
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [InheritedExport(typeof(IPackage))]
    public abstract class Package<T> : IPackage where T : Package<T>, new()
    {
        protected BotBitsClient BotBits { get; private set; }

        protected Package()
        {
            var type = typeof(T);
            if (type != this.GetType())
                throw new InvalidOperationException("Packages must inherit Package<T> of their own type!");
            if (!type.IsSealed)
                throw new InvalidOperationException("Packages must be marked as sealed.");
        }

        void IPackage.Setup(BotBitsClient client)
        {
            this.BotBits = client;
        }

        void IPackage.SignalInitializeFinish()
        {
            this.OnInitializeFinish();
        }

        protected event EventHandler InitializeFinish;

        private void OnInitializeFinish()
        {
            EventHandler handler = this.InitializeFinish;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        [Pure]
        public static T Of([NotNull] BotBitsClient client)
        {
            if (client == null)
                throw new ArgumentNullException("client");

            return client.Get<T>();
        }
    }
}