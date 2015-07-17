using System;
using System.ComponentModel;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Runtime.Serialization;

namespace BotBits
{
    public abstract class Extension<T> where T : Extension<T>, new()
    {
        protected Extension()
        {
            throw new NotSupportedException("Do not call \"new\" on Extension classes, use .LoadInto(...) instead.");
        }

        protected virtual void Initialize(BotBitsClient client, object args)
        {
        }

        protected static bool LoadInto(BotBitsClient client, object args)
        {
            var type = typeof(T);
            if (!type.IsSealed)
                throw new InvalidOperationException("Extension classes must be marked as sealed!");

            if (IsLoadedInto(client)) return false;
            client.Extensions.Add(type);

            var assembly = Assembly.GetAssembly(type);
            using (var catalog = new AssemblyCatalog(assembly))
            {
                var obj = (T)FormatterServices.GetUninitializedObject(type);
                client.Packages.AddPackages(catalog, () => obj.Initialize(client, args));
            }

            return true;
        }

        public static bool IsLoadedInto(BotBitsClient client)
        {
            return client.Extensions.Contains(typeof(T));
        }
    }
}
