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
            foreach (var kv in this._channels.ToArray())
            {
                var channel = kv.Value;

                if (this._warning && channel.LastReceived != channel.LastSent && channel.SendRepeatCount < 3)
                {
                    channel.SendRepeatCount++;

                    var canSend = 1;
                    this.SplitBypassSend(channel.LastSent, kv.Key != String.Empty, msg =>
                    {
                        if (canSend-- > 0) this.SendChat(channel.LastSent, channel);
                    });
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

            Console.WriteLine(message);
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

            this.SplitBypassSend(e.Message, e.IsPrivateMessage, this.QueueChat);
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
                var message = e.Text.Substring(0, e.Text.Length - 1); // Bug ingame, space after each private message
                
                var channel = this.GetChatChannel(username);
                if (channel.LastSent == $"/pm {username} {message}") channel.LastReceived = $"/pm {username} {message}";
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
            if (chat != channel.LastChat)
            {
                channel.RepeatCount = 0;
                channel.LastChat = chat;
            }

            return ++channel.RepeatCount;
        }

        private void SplitBypassSend(string message, bool pm, Action<string> callback)
        {
            var channel = this.GetChannel(message);
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
                callback(prefix + truncated);
                message = message.Substring(truncated.Length);
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
            public string LastChat = string.Empty;
            public string LastReceived = string.Empty;
            public string LastSent = string.Empty;
            public int SendRepeatCount;
            public int RepeatCount;
        }
    }
}