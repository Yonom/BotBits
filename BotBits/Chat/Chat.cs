using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text.RegularExpressions;
using System.Timers;
using BotBits.Events;
using BotBits.SendMessages;

namespace BotBits
{
    public sealed class Chat : EventListenerPackage<Chat>, IDisposable, IChat
    {
        private class ChatChannel
        {
            public ConcurrentQueue<string> Queue = new ConcurrentQueue<string>();
            public string LastChat = String.Empty;
            public int RepeatCount;
            public string LastSent = String.Empty;
            public string LastReceived = String.Empty;
        }

        private readonly ConcurrentDictionary<string, ChatChannel> _channels
            = new ConcurrentDictionary<string, ChatChannel>();

        private readonly Timer _mySendTimer;
        private Players _players;
        private bool _warning;

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
            foreach (var channel in _channels.Values.ToArray())
            {
                if (this._warning && channel.LastReceived != channel.LastSent)
                {
                    this.SendChat(channel.LastSent, channel);
                }
                else
                {
                    string chatMessage;
                    if (channel.Queue.TryDequeue(out chatMessage))
                    {
                        this.SendChat(chatMessage, channel);
                    }
                    else
                    {
                        this._mySendTimer.Stop();
                    }
                }
            }
        }

        private void SendChat(string message, ChatChannel channel)
        {
            channel.LastSent = message;
            new ChatSendMessage(channel.LastSent)
                .SendIn(this.BotBits);
        }

        private void QueueChat(string msg)
        {
            msg = this.TrimChars(msg);
            var pm = msg.StartsWith("/pm", StringComparison.OrdinalIgnoreCase);

            // There is no speed limit on commands
            if (msg.StartsWith("/", StringComparison.OrdinalIgnoreCase) && !pm)
            {
                var e = msg.Length > 140
                    ? new ChatSendMessage(msg.Substring(0, 140))
                    : new ChatSendMessage(msg);
                e.SendIn(this.BotBits);
                return;
            }

            var channel = GetChannel(msg);

            // Dont send the same thing more than 3 times
            if (this.CheckHistory(msg, channel))
            {
                if (pm)
                    this.QueueChat(msg + ".");
                else
                    this.QueueChat("." + msg);
                return;
            }

            // Queue the message and chop it into 140 char parts
            {
                string prefix = String.Empty;
                string message = msg;
                if (pm)
                {
                    var args = msg.Split(' ');
                    prefix = String.Join(" ", args.Take(2)) + " ";
                    message = String.Join(" ", args.Skip(2));
                }

                var maxLength = 140 - prefix.Length;
                for (int i = 0; i < message.Length; i += maxLength)
                {
                    int left = message.Length - i;
                    this.Enqueue(prefix + (left > maxLength
                        ? message.Substring(i, maxLength)
                        : message.Substring(i, left)), channel);
                }
            }

            // Init Timer
            if (!this._mySendTimer.Enabled)
            {
                this.DoSendTick();

                this._mySendTimer.Start();
            }
        }

        private string GetChannel(string msg)
        {
            string channel = null;
            if (msg.StartsWith("/pm", StringComparison.OrdinalIgnoreCase))
                channel = msg.Split(' ').Skip(1).FirstOrDefault();
            return channel ?? String.Empty;
        }

        [EventListener(EventPriority.High)]
        private void OnChat(ChatEvent e)
        {
            if (e.Player == this._players.OwnPlayer)
            {
                var channel = this.GetChatChannel("");
                if (channel.LastSent == e.Text)
                    channel.LastReceived = e.Text;
            }
        }

        [EventListener(EventPriority.High)]
        private void OnWrite(WriteEvent e)
        {
            const string pmPrefix = "* ";
            const string pmSuffix = " > you";
            if (e.Title.StartsWith(pmPrefix) && e.Title.EndsWith(pmSuffix))
            {
                var username = e.Title.Substring(pmPrefix.Length, e.Title.Length - pmPrefix.Length - pmSuffix.Length);
                var message = e.Text.Substring(0, e.Text.Length - 1); // Bug ingame, space after each private message

                new PrivateMessageEvent(username, message)
                    .RaiseIn(this.BotBits);
            }
            else if (e.Title == "SYSTEM" &&
                     e.Text == "You are trying to chat too fast, spamming the chat is not nice!")
            {
                _warning = true;
            }
        }

        public void Say(string msg)
        {
            this.QueueChat(msg);
        }
        
        private void Enqueue(string str, string channel)
        {
            this.GetChatChannel(channel).Queue.Enqueue(str);
        }

        private bool CheckHistory(string str, string channel)
        {
            return this.GetChatRepeats(str, channel) > 4;
        }

        public int GetChatRepeats(string chat, string channel)
        {
            var c = this.GetChatChannel(channel);
            if (chat != c.LastChat)
            {
                c.RepeatCount = 0;
                c.LastChat = chat;
            }

            return ++c.RepeatCount;
        }

        private string TrimChars(String text)
        {
            //Limit range to 31 - 255
            text = Regex.Replace(text, @"[^\x1F-\xFF]", "").Trim();

            //Remove del char 127
            text = Regex.Replace(text, @"[\x7F]", "").Trim();

            return text;
        }

        private ChatChannel GetChatChannel(string channel)
        {
            return this._channels.GetOrAdd(channel, c => new ChatChannel());
        }
    }
}
