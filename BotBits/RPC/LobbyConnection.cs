using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using PlayerIOClient;

namespace BotBits
{
    class LobbyConnection : RPCConnection
    {
        private readonly Client _client;
        private readonly int _version;

        public LobbyConnection(Client client, int version)
        {
            this._client = client;
            this._version = version;
        }

        protected override Task<Connection> GetConnectionAsync()
        {
            return this._client.Multiplayer.CreateJoinRoomAsync(
                this._client.ConnectUserId, "Lobby" + this._version, true, null, null);
        }

        public Task<bool> GetProfileVisibilityAsync()
        {
            return this.MakeRPCCallAsync("getProfile")
                .Then(t => t.Result.GetBoolean(0));
        }

        public Task SetProfileVisibilityAsync(bool visible)
        {
            return this.MakeRPCCallAsync("toggleProfile", visible);
        }

        public Task<LoginRewardData> GetLoginRewardAsync()
        {
            return this.MakeRPCCallAsync("getLobbyProperties")
                .Then(t =>
                {
                    var message = t.Result;

                    var rewards = new List<Reward>();
                    for (var i = 2u; i < message.Count;)
                    {
                        var reward = message.GetString(i++);
                        var quantity = message.GetInt(i++);

                        rewards.Add(new Reward(reward, quantity));
                    }

                    return new LoginRewardData(message.GetBoolean(0), message.GetInt(1), rewards.ToArray());
                })
                .ToSafeTask();
        }

        // Todo test
        public Task<string[]> GetMyCouponsAsync()
        {
            return this.MakeRPCCallAsync(Message.Create("getMyCodes"), CancellationToken.None, "copyPrompt")
                .Then(t => t.Result.GetString(1) == "You don't have any active codes!"
                    ? new string[0]
                    : t.Result.GetString(1).Split('\n'))
                .ToSafeTask();
        }

        // Todo test
        public Task<string[]> UseCouponAsync(string coupon)
        {
            return this.MakeRPCCallAsync(Message.Create("getMyCodes"), CancellationToken.None, "copyPrompt")
                .Then(t => t.Result.GetString(1) == "You don't have any active codes!"
                    ? new string[0]
                    : t.Result.GetString(1).Split('\n'))
                .ToSafeTask();
        }
        
        public Task SetSmileyAsync(Smiley smiley)
        {
            return this.MakeRPCCallAsync("changeSmiley", (int)smiley);
        }
        
        public Task SetAuraAsync(AuraShape shape, AuraColor color)
        {
            return this.MakeRPCCallAsync("changeAura", (int)shape, (int)color);
        }
        
        public Task SetBadgeAsync(Badge badge)
        {
            return this.MakeRPCCallAsync("changeBadge", badge.ToString());
        }

        public Task<Mail[]> GetMailsAsync()
        {
            return this.MakeRPCCallAsync("getMails")
                .Then(t =>
                {
                    var message = t.Result;
                    var mails = new List<Mail>();
                    for (var i = 0u; i < message.Count;)
                    {
                        var key = message.GetString(i++);
                        var username = message.GetString(i++);
                        var subject = message.GetString(i++);
                        var body = message.GetString(i++);

                        mails.Add(new Mail(key, username, subject, body));
                    }
                    return mails.ToArray();
                })
                .ToSafeTask();
        }

        public Task<Notification[]> GetNotificationsAsync()
        {
            return this.MakeRPCCallAsync("getMails")
                .Then(t =>
                {
                    var message = t.Result;
                    var notifications = new List<Notification>();
                    for (var i = 0u; i < message.Count;)
                    {
                        var key = message.GetString(i++);
                        var channel = message.GetString(i++);
                        var title = message.GetString(i++);
                        var body = message.GetString(i++);
                        var publishDate =  DateTime.ParseExact(message.GetString(i++), "g", CultureInfo.InvariantCulture);
                        var roomId = message.GetString(i++);
                        var imageUrl = message.GetString(i++);

                        notifications.Add(new Notification(key, channel, title, body, publishDate, roomId, imageUrl));
                    }
                    return notifications.ToArray();
                })
                .ToSafeTask();
        }


        // TODO GetShop
        // GetCampaigns
        // useEnergy, useAllEnergy, useGems
        // settimezone
        // getnews
        // Wontdo getMySimplePlayerObject
    }

    public class LoginRewardData
    {
        public bool FirstLogin { get; }
        public int LoginStreak { get; }
        public Reward[] Rewards { get; }

        public LoginRewardData(bool firstLogin, int loginStreak, Reward[] rewards)
        {
            this.FirstLogin = firstLogin;
            this.LoginStreak = loginStreak;
            this.Rewards = rewards;
        }
    }

    public class Mail
    {
        public string Key { get; }
        public string Username { get; }
        public string Subject { get; }
        public string Body { get; }

        public Mail(string key, string username, string subject, string body)
        {
            this.Key = key;
            this.Username = username;
            this.Subject = subject;
            this.Body = body;
        }
    }

    public class Notification
    {
        public string Channel { get;}
        public string Key { get; }
        public string Body { get; }
        public string Title { get; }
        public DateTime PublishDate { get; }
        public string RoomId { get;  }
        public string ImageUrl { get;}

        public Notification(string key, string channel, string title, string body, DateTime publishDate, string roomId, string imageUrl)
        {
            this.Key = key;
            this.Channel = channel;
            this.Title = title;
            this.Body = body;
            this.PublishDate = publishDate;
            this.RoomId = roomId;
            this.ImageUrl = imageUrl;
        }
    }
}
