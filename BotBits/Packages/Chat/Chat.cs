using System;
using System.Collections.Concurrent;
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
            // Trim chars
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
            foreach (var channel in this._channels.Values.ToArray())
            {
                if (this._warning && channel.LastReceived != channel.LastSent && channel.SendRepeatCount < 3)
                {
                    channel.SendRepeatCount++;
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

            this._warning = false;
        }

        private void SendChat(string message, ChatChannel channel)
        {
            if (channel.LastSent != message)
            {
                channel.LastSent = message;
                channel.SendRepeatCount = 0;
            }

            new ChatSendMessage(channel.LastSent)
                .SendIn(this.BotBits);
        }

        private void QueueChat(string msg)
        {
            var channel = this.GetChannel(msg);
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

        private string GetChannel(string msg)
        {
            string channel = null;
            if (msg.StartsWith("/pm ", StringComparison.OrdinalIgnoreCase)) channel = msg.Split(' ').Skip(1).FirstOrDefault();
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
            
            var prefix = string.Empty;
            var message = e.Message;
            if (e.IsPrivateMessage)
            {
                var args = e.Message.Split(' ');
                prefix = string.Join(" ", args.Take(2)) + " ";
                message = string.Join(" ", args.Skip(2));
            }
            var maxLength = MaxLength - prefix.Length;

            while (message.Length > 0)
            {
                var channel = this.GetChannel(e.Message);
                var truncated = this.Truncate(message, maxLength);
                if (!Players.Of(this.BotBits).OwnPlayer.Owner &&
                    this.CheckHistory(truncated, channel))
                {
                    var bypass = '.';
                    if (truncated.All(c => c == bypass)) bypass = ',';
                    message = bypass + message;
                    truncated = this.Truncate(message, maxLength);
                }

                this.QueueChat(prefix + truncated);
                message = message.Substring(truncated.Length);
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
            const string pmPrefix = "* ";
            const string pmSuffix = " > you";
            const string pmSendPrefix = "* you > ";
            if (e.Title.StartsWith(pmPrefix) && e.Title.EndsWith(pmSuffix))
            {
                var username = e.Title.Substring(pmPrefix.Length, e.Title.Length - pmPrefix.Length - pmSuffix.Length);
                var message = e.Text.Substring(0, e.Text.Length - 1); // Bug ingame, space after each private message

                new PrivateMessageEvent(username, message)
                    .RaiseIn(this.BotBits);
            }
            else if (e.Title.StartsWith(pmSendPrefix))
            {
                var username = e.Title.Substring(pmSendPrefix.Length);
                var message = e.Text.Substring(0, e.Text.Length - 1); // Bug ingame, space after each private message

                var channel = this.GetChatChannel(username);
                if (channel.LastSent == message) channel.LastReceived = message;

            }
            else if (e.Title == "* SYSTEM" &&
                     e.Text == "You are trying to chat too fast, spamming the chat room is not nice!")
            {
                this._warning = true;
                this.InitTimer();
            }
        }

        private void Enqueue(string str, string channel)
        {
            this.GetChatChannel(channel).Queue.Enqueue(str);
        }

        private bool CheckHistory(string str, string channel)
        {
            str = this.Truncate(str);
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
            public string LastChat = string.Empty;
            public string LastReceived = string.Empty;
            public string LastSent = string.Empty;
            public int SendRepeatCount;
            public int RepeatCount;
        }
    }
}