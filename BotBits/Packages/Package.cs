using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using JetBrains.Annotations;

namespace BotBits
{
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    [InheritedExport(typeof(IPackage))]
    public abstract class Package<T> : IPackage where T : Package<T>, new()
    {
        protected Package()
        {
            var type = typeof(T);
            if (type != this.GetType()) throw new InvalidOperationException("Packages must inherit Package<T> of their own type!");
            if (!type.IsSealed) throw new InvalidOperationException("Packages must be marked as sealed.");
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected BotBitsClient BotBits { get; private set; }

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
            var handler = this.InitializeFinish;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        [Pure]
        public static T Of([NotNull] BotBitsClient client)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));

            return client.Packages.Get<T>();
        }
    }
}