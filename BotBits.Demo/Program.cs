using System;
using System.Diagnostics;
using System.Threading;
using BotBits.Events;
using BotBits.SendMessages;

namespace BotBits.Demo
{
    internal class Program
    {
        private static BotBitsClient bot = new BotBitsClient();

        private static void Main()
        {
            ConnectionManager
                .Of(bot)
                .GuestLogin()
                .CreateOpenWorld("Hai");

            Thread.Sleep(Timeout.Infinite);
        }
    }
}