using System;
using System.Threading;
using BotBits.Events;
using BotBits.SendMessages;

namespace BotBits.Demo
{
    class Program
    {
        static BotBitsClient bot = new BotBitsClient();

        static void Main()
        {
            EventLoader
                .Of(bot)
                .LoadStatic<Program>();

            ConnectionManager
                .Of(bot)
                .EmailLogin("", "")
                .CreateJoinRoom("PWAARLDluVa0I");

            Thread.Sleep(-1);
        }


        [EventListener]
        static void OnJoin(JoinEvent e)
        {    
        }
    }
}