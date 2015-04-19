using System;
using System.Collections.Generic;
using System.Threading;
using BotBits;
using BotBits.Events;

namespace BotBits.Demo
{
    internal class Program
    {
        // Aura
        // TODO add custom Color class
        private static BotBitsClient bot = new BotBitsClient();

        private static void Main()
        {
            ConnectionManager
                .Of(bot)
                .GuestLogin()
                .CreateJoinRoom("world");

            Thread.Sleep(Timeout.Infinite);
        }
    }
}