using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Diagnostics;
using System.Linq;
using JetBrains.Annotations;

namespace BotBits
{
    [DebuggerTypeProxy(typeof(DebugView))]
    internal sealed class PackageLoader : IDisposable
    {
        private readonly BotBitsClient _client;
        private readonly List<CompositionContainer> _containers = new List<CompositionContainer>();
        private readonly ConcurrentDictionary<Type, IPackage> _packages = new ConcurrentDictionary<Type, IPackage>();

        [ImportMany]
        [UsedImplicitly(ImplicitUseKindFlags.Access)]
        private IPackage[] _importedPackages;

        public PackageLoader(BotBitsClient client)
        {
            this._client = client;
        }

        public void Dispose()
        {
            lock (this._containers)
            {
                this._containers.ForEach(c => c.Dispose());
            }
        }

        public void AddPackages(ComposablePartCatalog catalog, [CanBeNull] Action initialize)
        {
            lock (this._containers)
            {
                var container = new CompositionContainer(catalog);

                try
                {
                    container.ComposeParts(this);
                    try
                    {
                        this.LoadPackages(this._importedPackages, initialize);
                        this._containers.Add(container);
                    }
                    catch (Exception)
                    {
                        this.UnloadPackages(this._importedPackages);
                        throw;
                    }
                }
                catch
                {
                    container.Dispose();
                    throw;
                }
                finally
                {
                    this._importedPackages = null;
                }
            }
        }

        public T Get<T>() where T : Package<T>, new()
        {
            var t = typeof(T);
            IPackage value;

            if (this._packages.TryGetValue(t, out value)) return (T)value;
            throw new NotSupportedException($"The package {t.FullName} has not been loaded into BotBits.");
        }

        private void LoadPackages(IPackage[] packages, [CanBeNull] Action initialize)
        {
            foreach (var l in packages)
            {
                l.Setup(this._client);
                this._packages.TryAdd(l.GetType(), l);
            }
            initialize?.Invoke();
            foreach (var l in packages)
            {
                l.SignalInitializeFinish();
            }
        }

        private void UnloadPackages(IEnumerable<IPackage> packages)
        {
            foreach (var l in packages)
            {
                IPackage output;
                this._packages.TryRemove(l.GetType(), out output);
            }
        }

        private class DebugView
        {
            private readonly PackageLoader _loader;

            public DebugView(PackageLoader loader)
            {
                this._loader = loader;
            }

            [DebuggerBrowsable(DebuggerBrowsableState.RootHidden), UsedImplicitly]
            private PackageView[] Items
            {
                get
                {
                    lock (this._loader._packages)
                    {
                        return this._loader._packages.Select(kv => new PackageView(kv.Key, kv.Value)).ToArray();
                    }
                }
            }

            [DebuggerDisplay("{_package}", Name = "{_type.Name,nq}")]
            private class PackageView
            {
                [DebuggerBrowsable(DebuggerBrowsableState.RootHidden), UsedImplicitly]
                private readonly IPackage
                    _package;

                [DebuggerBrowsable(DebuggerBrowsableState.Never), UsedImplicitly]
                private readonly Type _type;

                public PackageView(Type type, IPackage package)
                {
                    this._type = type;
                    this._package = package;
                }
            }
        }
    }
}