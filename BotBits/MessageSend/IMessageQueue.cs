using System;
using BotBits.Events;
using BotBits.SendMessages;
using PlayerIOClient;

namespace BotBits
{
    internal interface IMessageQueue
    {
        void SendTicks(int ticks, Connection connection);
    }
}