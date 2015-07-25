using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using BotBits.Events;
using BotBits.SendMessages;
using PlayerIOClient;

namespace BotBits
{
    internal sealed class MessageHandler : EventListenerPackage<MessageHandler>
    {
        private readonly MessageRegister _messageRegister = new MessageRegister();

        [Obsolete("Invalid to use \"new\" on this class. Use the static .Of(botBits) method instead.", true)]
        public MessageHandler()
        {
            foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
            {
                var attr = (ReceiveEventAttribute)type.GetCustomAttributes(
                    typeof(ReceiveEventAttribute), true).FirstOrDefault();
                if (attr != null)
                {
                    _messageRegister.RegisterMessage(attr.Type, type);
                }
            }
        }

        [EventListener]
        private void OnInit(InitEvent e)
        {
            new Init2SendMessage()
                .SendIn(this.BotBits);
        }

        [EventListener(EventPriority.Low)]
        private void OnMessage(PlayerIOMessageEvent e)
        {
            Type handler;
            if (this._messageRegister.TryGetHandler(e.Message.Type, out handler))
            {
                IEvent instance;
                try
                {
                    const BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Instance;
                    instance = (IEvent)Activator.CreateInstance(handler, flags, null,
                        new object[] { this.BotBits, e.Message }, null);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error parsing message: {0} \n {1}", e.Message, ex);
                    return;
                }

                var playerEvent = instance as IPlayerEvent;
                if (playerEvent != null && playerEvent.Player == null)
                    return;

                instance.RaiseIn(this.BotBits);
            }
            else
            {
                new UnknownMessageEvent(this.BotBits, e.Message)
                    .RaiseIn(this.BotBits);
            }
        }

        
    }
}