using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using BotBits.Events;

namespace BotBits.Demo
{
    internal class Program
    {
        private static BotBitsClient bot = new BotBitsClient();

        private static void Main()
        {
            EventLoader
                .Of(bot)
                .LoadStatic<Program>();

            ConnectionManager
                .Of(bot)
                .GuestLogin()
                .CreateJoinRoom("PWUKW1nu-Ta0I");

            Thread.Sleep(-1);
        }
    }
}