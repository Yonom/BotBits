using System;
using System.Linq;
using System.Threading;
using BotBits.Events;

namespace BotBits.Demo
{
    internal class Program
    {
        private static readonly BotBitsClient bot = new BotBitsClient();

        private static void Main()
        {
            EventLoader.Of(bot).LoadStatic<Program>();

            Login.Of(bot).AsGuest().CreateJoinRoom("PW01");

            Thread.Sleep(Timeout.Infinite);
        }

        [EventListener]
        static void On(SignPlaceEvent e)
        {
            Console.WriteLine("sign placed");
        }
    }
}