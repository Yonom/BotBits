using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using BotBits.Events;
using BotBits.SendMessages;
using PlayerIOClient;

namespace BotBits
{
    internal sealed class MessageHandler : EventListenerPackage<MessageHandler>, IDisposable
    {
        private ConnectionManager _connectionManager;
        private readonly MessageRegister _messageRegister = new MessageRegister();

        [Obsolete("Invalid to use \"new\" on this class. Use the static .Of(botBits) method instead.", true)]
        public MessageHandler()
        {
            this.InitializeFinish += this.OnInitializeFinish;

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

        private void OnInitializeFinish(object sender, EventArgs eventArgs)
        {
            this._connectionManager = ConnectionManager.Of(this.BotBits);
        }

        void IDisposable.Dispose()
        {
            if (this._connectionManager != null)
                if (this._connectionManager.Connection != null)
                    this._connectionManager.Connection.OnMessage -= this.Connection_OnMessage;
        }

        [EventListener(EventPriority.High)]
        private void OnConnect(ConnectEvent e)
        {
            this._connectionManager.Connection.OnMessage += this.Connection_OnMessage;

            new InitSendMessage()
                .SendIn(this.BotBits);
        }

        [EventListener(EventPriority.High)]
        private void OnInit(InitEvent e)
        {
            new Init2SendMessage()
                .SendIn(this.BotBits);
        }

        private void Connection_OnMessage(object sender, Message e)
        {
           this.BotBits.Schedule(() => this.HandleMessage(e)).Wait();
        }

        private void HandleMessage(Message e)
        {
            Type handler;
            if (this._messageRegister.TryGetHandler(e.Type, out handler))
            {
                const BindingFlags flags = BindingFlags.NonPublic | BindingFlags.Instance;
                var instance = (IEvent)Activator.CreateInstance(handler, flags, null, 
                    new object[] { this.BotBits, e }, null);

                instance.RaiseIn(this.BotBits);
            }
            else
            {
                new UnknownMessageEvent(this.BotBits, e)
                    .RaiseIn(this.BotBits);
            }
        }
    }
}