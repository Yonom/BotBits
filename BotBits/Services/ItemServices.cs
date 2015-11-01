using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BotBits.Shop;

namespace BotBits
{
    public static class ItemServices
    {
        private static readonly Dictionary<Smiley, PackAttribute> _smileyPacks = new Dictionary<Smiley, PackAttribute>();
        private static readonly Dictionary<Aura, PackAttribute> _auraPacks = new Dictionary<Aura, PackAttribute>();
        private static readonly Dictionary<int, PackAttribute> _blockPacks = new Dictionary<int, PackAttribute>();
        private static readonly Dictionary<int, Type> _blockGroups = new Dictionary<int, Type>();

        static ItemServices()
        {
            LoadPacks(typeof (Background));
            LoadPacks(typeof (Foreground));
            LoadEnum(_smileyPacks);
            LoadEnum(_auraPacks);
        }

        public static KeyValuePair<int, Type>[] GetGroups()
        {
            return _blockGroups.ToArray();
        }

        public static Type GetGroup(int id)
        {
            Type type;
            _blockGroups.TryGetValue(id, out type);
            return type;
        }

        public static PackAttribute GetPackage(Foreground.Id id)
        {
            return GetPackageInternal((int) id);
        }

        public static PackAttribute GetPackage(Background.Id id)
        {
            return GetPackageInternal((int) id);
        }

        public static PackAttribute GetPackage(Aura id)
        {
            PackAttribute pack;
            _auraPacks.TryGetValue(id, out pack);
            return pack;
        }

        public static PackAttribute GetPackage(Smiley id)
        {
            PackAttribute pack;
            _smileyPacks.TryGetValue(id, out pack);
            return pack;
        }

        internal static PackAttribute GetPackageInternal(int id)
        {
            PackAttribute pack;
            _blockPacks.TryGetValue(id, out pack);
            return pack;
        }

        private static void LoadPacks(Type type)
        {
            foreach (var field in type.GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                var value = (ushort) field.GetValue(null);
                _blockGroups[value] = type;

                var pack = GetPack(field);
                if (pack != null)
                    _blockPacks.Add(value, pack);
            }

            foreach (var i in type.GetNestedTypes())
            {
                LoadPacks(i);
            }
        }


        private static void LoadEnum<T>(Dictionary<T, PackAttribute> collection)
        {
            foreach (var field in typeof (T).GetFields(BindingFlags.Static | BindingFlags.Public))
            {
                var pack = GetPack(field);
                if (pack != null)
                {
                    collection.Add((T) field.GetValue(null), pack);
                }
            }
        }

        private static PackAttribute GetPack(ICustomAttributeProvider provider)
        {
            return (PackAttribute) provider
                .GetCustomAttributes(typeof (PackAttribute), false)
                .FirstOrDefault();
        }
    }
}