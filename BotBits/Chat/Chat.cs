using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using BotBits.Annotations;
using BotBits.Events;
using BotBits.SendMessages;

namespace BotBits
{
    public sealed class Chat : EventListenerPackage<Chat>, IDisposable
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
            if (msg.StartsWith("/", StringComparison.Ordinal))
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

        public void GiveEdit(string username)
        {
            this.Say("/giveedit {0}", username);
        }

        public void RemoveEdit(string username)
        {
            this.Say("/removeedit {0}", username);
        }

        public void Teleport(string username)
        {
            this.Say("/teleport {0}", username);
        }

        public void Teleport(string username, int x, int y)
        {
            this.Say("/teleport {0} {1} {2}", username, x, y);
        }

        public void Kick(string username)
        {
            this.Say("/kick {0}", username);
        }

        public void Kick(string username, string reason)
        {
            this.Say("/kick {0} {1}", username, reason);
        }

        public void KickGuests()
        {
            this.Say("/kickguests");
        }

        public void Kill(string username)
        {
            this.Say("/kill {0}", username);
        }

        public void KillAll()
        {
            this.Say("/killemall");
        }

        public void Mute(string username)
        {
            this.Say("/mute {0}", username);
        }

        public void Unmute(string username)
        {
            this.Say("/unmute {0}", username);
        }

        public void ReportAbuse(string username, string reason)
        {
            this.Say("/reportabuse {0} {1}", username, reason);
        }

        public void Reset()
        {
            this.Say("/reset");
        }

        public void Respawn()
        {
            this.Say("/respawn");
        }

        public void RespawnAll()
        {
            this.Say("/respawnall");
        }

        public void PotionsOn(params string[] potions)
        {
            this.Say("/potionson  {0}", String.Join(" ", potions));
        }

        public void PotionsOn(params int[] potions)
        {
            this.Say("/potionson  {0}", String.Join(" ", potions));
        }

        public void PotionsOn(params Potion[] potions)
        {
            this.Say("/potionson {0}", String.Join(" ", potions.Cast<int>()));
        }

        public void PotionsOff(params string[] potions)
        {
            this.Say("/potionsoff {0}", String.Join(" ", potions));
        }

        public void PotionsOff(params int[] potions)
        {
            this.Say("/potionsoff {0}", String.Join(" ", potions));
        }

        public void PotionsOff(params Potion[] potions)
        {
            this.Say("/potionsoff {0}", String.Join(" ", potions.Cast<int>()));
        }

        public void ChangeVisibility(bool visible)
        {
            this.Say("/visible {0}", visible);
        }

        public void LoadLevel()
        {
            this.Say("/loadlevel");
        }
        
        public void SetBackgroundColor(string color)
        {
            this.Say("/bgcolor {0}", color);
        }

        public void SetBackgroundColor(byte r, byte g, byte b)
        {
            this.Say("/bgcolor #{0:x2}{1:x2}{2:x2}", r, g, b);
        }

        public void ListPortals()
        {
            this.Say("/listportals");
        }

        public void GetBlockPlacer()
        {
            this.Say("/getblockplacer");
        }

        public void GetPosition()
        {
            this.Say("/getpos");
        }
    }
}