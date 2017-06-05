using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using BotBits.Events;
using BotBits.SendMessages;

namespace BotBits
{
    internal sealed class MessageHandler : EventListenerPackage<MessageHandler>
    {
        private readonly MessageRegister _messageRegister = new MessageRegister();
        private InfoEvent _lastInfo;

        [Obsolete("Invalid to use \"new\" on this class. Use the static .Of(BotBits) method instead.", true)]
        public MessageHandler()
        {
            foreach (var type in Assembly.GetExecutingAssembly().GetTypes())
            {
                var attr = (ReceiveEventAttribute)type.GetCustomAttributes(
                        typeof(ReceiveEventAttribute), true)
                    .FirstOrDefault();
                if (attr != null)
                {
                    if (!this._messageRegister.RegisterMessage(attr.Type, type))
                    {
                        throw new InvalidOperationException($"Unable to bind message type {attr.Type} to {type.Name}.");
                    }
                }
            }
        }

        [EventListener]
        private void On(ConnectEvent e)
        {
            new InitSendMessage()
                .SendIn(this.BotBits);
        }

        [EventListener]
        private void On(InitEvent e)
        {
            new Init2SendMessage()
                .SendIn(this.BotBits);
        }

        [EventListener]
        private void On(InfoEvent e)
        {
            this._lastInfo = e;
        }

        [EventListener]
        private void On(DisconnectEvent e)
        {
            if (!Room.Of(this.BotBits).JoinComplete)
            {
                new JoinFailureEvent(this._lastInfo.Title, this._lastInfo.Text)
                    .RaiseIn(this.BotBits);
            }
        }

        [EventListener]
        private void On(InvalidMessageEvent e)
        {
            Trace.TraceWarning($"Received invalid message: {e.Reason}\n{e.PlayerIOMessage}");
        }

        [EventListener]
        private void On(PlayerIOMessageEvent e)
        {
            Type handler;
            if (this._messageRegister.TryGetHandler(e.Message.Type, out handler))
            {
                const BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Instance;
                var instance = (IEvent)Activator.CreateInstance(handler, flags, null,
                    new object[] { this.BotBits, e.Message }, null);

                var playerEvent = instance as ICancellable;
                if (playerEvent != null && playerEvent.Cancelled)
                {
                    new InvalidMessageEvent(this.BotBits, e.Message,
                            new UnknownPlayerException("The player could not be found."))
                        .RaiseIn(this.BotBits);
                    return;
                }

                instance.RaiseIn(this.BotBits);
            }
            else
            {
                new InvalidMessageEvent(this.BotBits, e.Message,
                        new UnknownMessageTypeException("The received message type is not supported."))
                    .RaiseIn(this.BotBits);
            }
        }
    }
}