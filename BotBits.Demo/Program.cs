using System;
using BotBits.Events;

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
                .EmailLogin("sepi1376@gmail.com", "1346279")
                .CreateJoinRoom("PWXRezGVBebEI");

            Chat.Of(bot).Kill()
            Console.ReadLine();
        }

        [EventListener]
        void OnInit(InitEvent e)
        {
            for (var x = 0; x < 20; x++)
            {
                for (var y = 0; y < 20; y++)
                {
                    Blocks.Of(bot).Place(x, y, Foregrounds.Basic.Gray);
                }
            }
        }

        [EventListener]
        void OnLeft(JoinEvent e)
        {
            Console.WriteLine("Player left: " + e.Username);
        }
    }
}