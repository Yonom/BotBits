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

        public static void RunOnContext(this BotBitsClient client, Action action)
        {
            client.SynchronizationContext.Send(o => action(), null);
        }

        public static Point3D GetPoint3D(this PlaceSendMessage placeSendMessage)
        {
            return new Point3D(placeSendMessage.Layer, placeSendMessage.X, placeSendMessage.Y);
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

        public static string Rot13(string input)
        {
            char[] array = input.ToCharArray();
            for (int i = 0; i < array.Length; i++)
            {
                var number = (int)array[i];

                if (number >= 'a' && number <= 'z')
                {
                    if (number > 'm')
                    {
                        number -= 13;
                    }
                    else
                    {
                        number += 13;
                    }
                }
                else if (number >= 'A' && number <= 'Z')
                {
                    if (number > 'M')
                    {
                        number -= 13;
                    }
                    else
                    {
                        number += 13;
                    }
                }
                array[i] = (char)number;
            }
            return new string(array);
        }
    }
}