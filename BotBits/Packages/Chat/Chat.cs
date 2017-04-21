using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
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
            this._mySendTimer = new Timer(o => this.DoSendTick(), null, 0, 600);
        }

        void IDisposable.Dispose()
        {
            this._mySendTimer.Dispose();
        }

        public void Say(string msg)
        {
            // Strip unallowed characters
            msg = Regex.Replace(msg, @"[^\x1F-\xFF]|[\x7F]", "").Trim();

            new QueueChatEvent(msg)
                .RaiseIn(this.BotBits);
        }

        [EventListener(GlobalPriority.AfterMost)]
        private void OnAfterMost(QueueChatEvent e)
        {
            if (e.Cancelled)
                return;

            if (e.IsCommand && !e.IsPrivateMessage)
            {
                new ChatSendMessage(Truncate(e.Message))
                    .SendIn(this.BotBits);
            }
            else
            {
                foreach (var msg in this.SplitMessage(e.Message, e.IsPrivateMessage))
                {
                    this.QueueChat(msg, e.IsPrivateMessage);
                }
            }
        }

        private IEnumerable<string> SplitMessage(string message, bool pm)
        {
            var channel = GetChannel(message, pm);
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
                message = this.BypassMessage(message, channel, maxLength);

                var truncated = Truncate(message, maxLength);
                message = message.Substring(truncated.Length);
                yield return prefix + truncated;
            }
        }

        private string BypassMessage(string message, string channel, int maxLength)
        {
            var truncated = Truncate(message, maxLength);

            if (!Players.Of(this.BotBits).OwnPlayer.Owner &&
                this.CheckHistory(truncated, channel))
            {
                if (truncated.Length < maxLength)
                {
                    message = '.' + message;
                }
                else
                {
                    var bypass = '.';
                    if (truncated.All(c => c == bypass))
                        bypass = ',';
                    message = bypass + message;
                }
            }

            return message;
        }

        private void QueueChat(string msg, bool pm)
        {
            DiagnosticServices.Chat_QueueChat(this.BotBits);

            var channel = GetChannel(msg, pm);
            this.Enqueue(msg, channel);
        }

        private void DoSendTick()
        {
            foreach (var kv in this._channels.ToArray())
            {
                var channel = kv.Value;
                var pm = kv.Key != String.Empty;
                
                if (channel.LastSent != channel.LastReceived)
                {
                    if (this._warning)
                    {
                        this.SendChat(this.SplitMessage(channel.LastSent, pm).First(), channel);
                    }
                    else if (pm && Players.Of(this.BotBits).FromUsername(kv.Key).Length <= 0)
                    {
                        // player left
                        channel.LastSent = channel.LastReceived;
                    }
                    else if (++channel.DelayCount >= 10)
                    {
                        channel.LastSent = channel.LastReceived;
                    }
                    // nofix: When disconnected, chat keeps trying to resend
                }
                else
                {
                    channel.DelayCount = 0;

                    string chatMessage;
                    if (channel.Queue.TryDequeue(out chatMessage))
                    {
                        this.SendChat(chatMessage, channel);
                    }
                }
            }

            this._warning = false;
        }

        private void SendChat(string message, ChatChannel channel)
        {
            channel.LastSent = message;

            new ChatSendMessage(message)
                .SendIn(this.BotBits);
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
                var message = e.Text.TrimEnd(' '); // Bug ingame, space after each private message

                new PrivateMessageEvent(username, message)
                    .RaiseIn(this.BotBits);
            }
            else if (e.Type == WriteType.SentPrivateMessage)
            {
                var username = e.GetUser();
                var message = $"/pm {username} {e.Text.TrimEnd(' ')}"; // Bug ingame, space after each private message
                
                var channel = this.GetChatChannel(username);
                if (channel.LastSent == message) channel.LastReceived = message;
            }
            else if (e.Type == WriteType.ChattingTooFast)
            {
                this._warning = true;
            }
        }

        private void Enqueue(string str, string channel)
        {
            this.GetChatChannel(channel).Queue.Enqueue(str);
        }

        private bool CheckHistory(string str, string channel)
        {
            str = Truncate(str);
            var c = this.GetChatChannel(channel);

            lock (this._channels)
            {
                if (GetChatRepeats(str, c) > 4)
                {
                    c.RepeatCount = 0;
                    return true;
                }
                return false;
            }
        }

        private static string GetChannel(string msg, bool pm)
        {
            string channel = null;
            if (pm)
                channel = msg.Split(' ').Skip(1).FirstOrDefault();
            return channel ?? string.Empty;
        }

        private static int GetChatRepeats(string chat, ChatChannel channel)
        {
            if (chat != channel.LastQueued)
            {
                channel.RepeatCount = 0;
                channel.LastQueued = chat;
            }

            return ++channel.RepeatCount;
        }

        private static string Truncate(string input, int length = MaxLength)
        {
            if (input.Length < length) return input;
            return input.Substring(0, length);
        }

        private ChatChannel GetChatChannel(string channel)
        {
            return this._channels.GetOrAdd(channel.ToUpperInvariant(), c => new ChatChannel());
        }

        private class ChatChannel
        {
            public readonly ConcurrentQueue<string> Queue = new ConcurrentQueue<string>();
            public string LastQueued = string.Empty;
            public string LastSent = string.Empty;
            public string LastReceived = string.Empty;
            public int RepeatCount;
            public int DelayCount;
        }
    }
}