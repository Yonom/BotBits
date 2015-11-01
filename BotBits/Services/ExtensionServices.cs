using System;
using System.Reflection;

namespace BotBits
{
    public static class ExtensionServices
    {
        public static Type[] GetExtensions(BotBitsClient client)
        {
            lock (client.Extensions)
                return client.Extensions.ToArray();
        }

        internal static int? GetExtensionId(BotBitsClient client, Assembly assembly)
        {
            var exts = GetExtensions(client);
            for (var i = 0; i < exts.Length; i++)
            {
                if (exts[i].Assembly == assembly)
                    return i;
            }
            return null;
        }
    }
}