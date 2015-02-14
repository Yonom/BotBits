using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using BotBits.Events;
using BotBits.SendMessages;

namespace BotBits
{
    public sealed class Chat : EventListenerPackage<Chat>, IDisposable, IChat
    {
        private readonly ConcurrentQueue<string> _myChatQueue = new ConcurrentQueue<string>();
        private readonly List<string> _myHistoryList = new List<string>(10);
        private readonly Timer _mySendTimer;
        private Players _players;
        private string _lastReceived = String.Empty;
        private string _lastSent = String.Empty;

        [Obsolete("Invalid to use \"new\" on this class. Use the static .Of(botBits) method instead.", true)]
        public Chat()
        {
            this._mySendTimer = new Timer(600); 
            this._mySendTimer.Elapsed += this.SendTimer_Elapsed;
            this.InitializeFinish += Chat_InitializeFinish;
        }

        void Chat_InitializeFinish(object sender, EventArgs e)
        {
            this._players = Players.Of(this.BotBits);
        }

        void IDisposable.Dispose()
        {
            this._mySendTimer.Dispose();
        }

        private void SendTimer_Elapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            this.DoSendTick();
        }

        private void DoSendTick()
        {
            if (this._lastReceived != this._lastSent)
            {
                this.SendChat(this._lastSent);
            }
            else
            {
                string chatMessage;
                if (this._myChatQueue.TryDequeue(out chatMessage))
                {
                    this.SendChat(chatMessage);
                }
                else
                {
                    this._mySendTimer.Stop();
                }
            }
        }

        private void SendChat(string message)
        {
            this._lastSent = message;
            new ChatSendMessage(this._lastSent)
                .SendIn(this.BotBits);
        }

        private bool CheckHistory(string str)
        {
            return this._myHistoryList.Count(str.Equals) >= 4;
        }

        private void QueueChat(string msg)
        {
            // There is no speed limit on commands
            if (msg.StartsWith("/", StringComparison.Ordinal) && 
                !msg.StartsWith("/pm", StringComparison.OrdinalIgnoreCase))
            {
                var e = msg.Length > 80
                    ? new ChatSendMessage(msg.Substring(0, 80))
                    : new ChatSendMessage(msg);
                e.SendIn(this.BotBits);
                return;
            }

            // Dont send the same thing more than 3 times
            if (this.CheckHistory(msg))
            {
                if (msg.StartsWith("/", StringComparison.Ordinal))
                    this.QueueChat(msg + ".");
                else
                    this.QueueChat("." + msg);
                return;
            }

            lock (this._myHistoryList)
            {
                if (this._myHistoryList.Count >= 10)
                    this._myHistoryList.RemoveAt(0);

                this._myHistoryList.Add(msg);
            }

            // Queue the message and chop it into 80 char parts
            for (int i = 0; i < msg.Length; i += 80)
            {
                int left = msg.Length - i;
                this._myChatQueue.Enqueue(left > 80
                    ? msg.Substring(i, 80)
                    : msg.Substring(i, left));
            }

            // Init Timer
            if (!this._mySendTimer.Enabled)
            {
                this.DoSendTick();

                this._mySendTimer.Start();
            }
        }

        [EventListener(EventPriority.High)]
        private void OnChat(ChatEvent e)
        {
            if (e.Player == this._players.OwnPlayer)
            {
                if (this._lastSent == e.Text)
                    this._lastReceived = e.Text;
            }
        }

        public void Say(string msg)
        {
            this.QueueChat(msg);
        }
    }
}