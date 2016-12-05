using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Timers;
using BotBits.Events;
using BotBits.SendMessages;

namespace BotBits
{
    public sealed class Chat : EventListenerPackage<Chat>, IDisposable, IChat
    {
        public const int MaxLength = 140;

        private readonly ConcurrentDictionary<string, ChatChannel> _channels
            = new ConcurrentDictionary<string, ChatChannel>();

        private readonly Timer _mySendTimer;
        private bool _warning;

        public int Count
        {
            get
            {
                return this._channels.Sum(c => c.Value.Queue.Count);
            }
        }

        [Obsolete("Invalid to use \"new\" on this class. Use the static .Of(BotBits) method instead.", true)]
        public Chat()
        {
            this._mySendTimer = new Timer(600);
            this._mySendTimer.Elapsed += this.SendTimer_Elapsed;
        }

        public void Say(string msg)
        {
            msg = this.TrimChars(msg);
            new QueueChatEvent(msg)
                .RaiseIn(this.BotBits);
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
            foreach (var kv in this._channels.ToArray())
            {
                var channel = kv.Value;

                if (this._warning && channel.LastSent != channel.LastReceived)
                {
                    this.SendChat(this.SplitBypassSend(channel.LastSent, kv.Key != String.Empty).First(), channel);
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

            this._warning = false;
        }

        private void SendChat(string message, ChatChannel channel)
        {
            channel.LastSent = message;
            new ChatSendMessage(channel.LastSent)
                .SendIn(this.BotBits);
        }

        private void QueueChat(string msg, bool pm)
        {
            var channel = this.GetChannel(msg, pm);
            this.Enqueue(msg, channel);

            this.InitTimer();
        }

        private void InitTimer()
        {
            if (!this._mySendTimer.Enabled)
            {
                this.DoSendTick();

                this._mySendTimer.Start();
            }
        }

        private string GetChannel(string msg, bool pm)
        {
            string channel = null;
            if (pm) channel = msg.Split(' ').Skip(1).FirstOrDefault();
            return channel ?? string.Empty;
        }


        [EventListener(GlobalPriority.AfterMost)]
        private void OnAfterMost(QueueChatEvent e)
        {
            if (e.Cancelled) return;

            if (e.IsCommand && !e.IsPrivateMessage)
            {
                new ChatSendMessage(this.Truncate(e.Message))
                    .SendIn(this.BotBits);
                return;
            }

            foreach (var msg in this.SplitBypassSend(e.Message, e.IsPrivateMessage))
            {
                this.QueueChat(msg, e.IsPrivateMessage);
            }
        }

        [EventListener]
        private void On(ChatEvent e)
        {
            if (e.Player == Players.Of(this.BotBits).OwnPlayer)
            {
                var channel = this.GetChatChannel("");
                if (channel.LastSent == e.Text) channel.LastReceived = e.Text;
            }
        }

        [EventListener]
        private void On(WriteEvent e)
        {
            if (e.Type == WriteType.ReceivedPrivateMessage)
            {
                var username = e.GetUser();
                var message = e.Text.Substring(0, e.Text.Length - 1); // Bug ingame, space after each private message

                new PrivateMessageEvent(username, message)
                    .RaiseIn(this.BotBits);
            }
            else if (e.Type == WriteType.SentPrivateMessage)
            {
                var username = e.GetUser();
                var message = $"/pm {username} {e.Text.Substring(0, e.Text.Length - 1)}"; // Bug ingame, space after each private message
                
                var channel = this.GetChatChannel(username);
                if (channel.LastSent == message) channel.LastReceived = message;
            }
            else if (e.Type == WriteType.ChattingTooFast)
            {
                this._warning = true;
                this.InitTimer();
            }
            else
            {
                Console.WriteLine(e.Text);
            }
        }

        private void Enqueue(string str, string channel)
        {
            this.GetChatChannel(channel).Queue.Enqueue(str);
        }

        private bool CheckHistory(string str, string channel)
        {
            str = this.Truncate(str);
            var c = this.GetChatChannel(channel);
            if (this.GetChatRepeats(str, c) > 4)
            {
                c.RepeatCount = 0;
                return true;
            }
            return false;
        }

        private int GetChatRepeats(string chat, ChatChannel channel)
        {
            if (chat != channel.LastSent)
            {
                channel.RepeatCount = 0;
                channel.LastSent = chat;
            }

            return ++channel.RepeatCount;
        }

        private IEnumerable<string> SplitBypassSend(string message, bool pm)
        {
            var channel = this.GetChannel(message, pm);
            var prefix = string.Empty;
            if (pm)
            {
                var args = message.Split(' ');
                prefix = string.Join(" ", args.Take(2)) + " ";
                message = string.Join(" ", args.Skip(2));
            }
            var maxLength = MaxLength - prefix.Length;

            while (message.Length > 0)
            {
                var truncated = this.Truncate(message, maxLength);

                if (!Players.Of(this.BotBits).OwnPlayer.Owner &&
                    this.CheckHistory(truncated, channel))
                {
                    var bypass = '.';
                    if (truncated.All(c => c == bypass))
                        bypass = ',';
                    message = bypass + message;
                    truncated = this.Truncate(message, maxLength);
                }
                message = message.Substring(truncated.Length);
                
                yield return prefix + truncated;
            }
        }

        private string TrimChars(string text)
        {
            //Limit range to 31 - 255
            text = Regex.Replace(text, @"[^\x1F-\xFF]", "").Trim();

            //Remove del char 127
            text = Regex.Replace(text, @"[\x7F]", "").Trim();

            return text;
        }

        private string Truncate(string input, int length = MaxLength)
        {
            if (input.Length < length) return input;
            return input.Substring(0, length);
        }

        private ChatChannel GetChatChannel(string channel)
        {
            return this._channels.GetOrAdd(channel, c => new ChatChannel());
        }

        private class ChatChannel
        {
            public readonly ConcurrentQueue<string> Queue = new ConcurrentQueue<string>();
            public string LastSent = string.Empty;
            public string LastReceived = string.Empty;
            public int RepeatCount;
        }
    }
}