using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BotBits
{
    internal static class Utils
    {
        public static IEnumerable<Type> GetTypesWithAttribute(Type t, Assembly assembly)
        {
            return assembly.GetTypes().Where(type => type.GetCustomAttributes(t, true).Length > 0);
        }

        public static bool IsEvent(Type givenType)
        {
            try
            {
// ReSharper disable once ReturnValueOfPureMethodIsNotUsed
                givenType.IsAssignableFrom(typeof (Event<>).MakeGenericType(givenType));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static IEnumerable<MethodInfo> GetMethods(Type type)
        {
            IEnumerable<MethodInfo> methods =
                type.GetMethods(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);

            if (type.BaseType?.BaseType != null)
            {
                methods = methods.Concat(GetMethods(type.BaseType));
            }

            return methods;
        }
    }
}