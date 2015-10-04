using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using BotBits.Events;
using BotBits.Nito.Async;
using BotBits.SendMessages;

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
                givenType.IsAssignableFrom(typeof(Event<>).MakeGenericType(givenType));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}