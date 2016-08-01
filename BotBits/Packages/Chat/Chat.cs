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
        private const int MaxMessageLength = 140;

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

        [EventListener]
        private void On(QueueChatEvent e)
        {
            // Trim chars
            e.Message = this.TrimChars(e.Message);

            // There is no speed limit on commands
            var pm = e.Message.StartsWith("/pm ", StringComparison.OrdinalIgnoreCase);
            if (e.Message.StartsWith("/", StringComparison.OrdinalIgnoreCase) && !pm)
            {
                new ChatSendMessage(this.Truncate(e.Message, MaxMessageLength))
                    .SendIn(this.BotBits);
                e.Cancelled = true;
                return;
            }

            // Queue the message and chop it into 140 char parts
            var prefix = string.Empty;
            var message = e.Message;
            if (pm)
            {
                var args = e.Message.Split(' ');
                prefix = string.Join(" ", args.Take(2)) + " ";
                message = string.Join(" ", args.Skip(2));
            }

            // Dont send the same thing more than 3 times
            var channel = this.GetChannel(e.Message);
            var maxLength = MaxMessageLength - prefix.Length;
            while (this.CheckHistory(this.Truncate(message, maxLength), channel))
            {
                message = "." + message;
            }

            if (message.Length > maxLength)
            {
                new QueueChatEvent(prefix + this.Truncate(message, maxLength))
                    .RaiseIn(this.BotBits);

                this.On(new QueueChatEvent(prefix + message.Substring(maxLength)));
            }
            else
            {
                e.Message = prefix + message;
            }
        }


        [EventListener(GlobalPriority.AfterMost)]
        private void OnAfterMost(QueueChatEvent e)
        {
            if (!e.Cancelled) this.QueueChat(e.Message);
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
            str = this.Truncate(str, MaxMessageLength);
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

        private string Truncate(string input, int length)
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
            public int RepeatCount;
        }
    }
}