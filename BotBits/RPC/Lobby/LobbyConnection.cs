using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PlayerIOClient;

namespace BotBits
{
    public class LobbyConnection : RPCConnection
    {
        private readonly Client _client;
        private readonly int _version;
        private const string Lobby = "Lobby";

        public LobbyConnection(Client client, int version)
        {
            this._client = client;
            this._version = version;
        }

        protected override Task<Connection> GetConnectionAsync()
        {
            return this._client.Multiplayer.CreateJoinRoomAsync(
                this._client.ConnectUserId, Lobby + this._version, true, null, null);
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
        
        public Task<string[]> GetMyCouponsAsync()
        {
            return this.MakeRPCCallAsync(Message.Create("getMyCodes"), "copyPrompt")
                .Then(t =>
                {
                    var res = t.Result.GetString(1).Split('\n');
                    return res.Take(res.Length - 1).ToArray();
                })
                .ToSafeTask();
        }
        
        public Task<bool> UseCouponAsync(string coupon)
        {
            return this.MakeRPCCallAsync("redeemCode", coupon)
                .Then(t => t.Result.GetBoolean(0))
                .ToSafeTask();
        }

        public Task<bool> GetCrewSubscriptionStatusAsync(Crew crew)
        {
            return this.MakeRPCCallAsync("isSubscribedToCrew", crew.Id)
                .Then(t => t.Result.GetBoolean(0))
                .ToSafeTask();
        }

        public Task<CrewMembershipData[]> GetMyCrewMemberships()
        {
            return this.MakeRPCCallAsync("getCrews")
                .Then(t =>
                {
                    var message = t.Result;
                    var crewMembershipDatas = new List<CrewMembershipData>();
                    for (var i = 0u; i < message.Count;)
                    {
                        var id = message.GetString(i++);
                        var name = message.GetString(i++);
                        var logoWorld = message.GetString(i++);

                        crewMembershipDatas.Add(new CrewMembershipData(id, name, logoWorld));
                    }
                    return crewMembershipDatas.ToArray();
                })
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
                        var id = message.GetString(i++);
                        var username = message.GetString(i++);
                        var subject = message.GetString(i++);
                        var body = message.GetString(i++);

                        mails.Add(new Mail(id, username, subject, body));
                    }
                    return mails.ToArray();
                })
                .ToSafeTask();
        }

        public Task SendMailAsync(Mail mail)
        {
            return this.MakeRPCCallAsync("sendMail", mail.Username, mail.Subject, mail.Body)
                .Then(t =>
                {
                    if (!t.Result.GetBoolean(0))
                        throw new MailDeliveryException(t.Result.GetString(1));
                })
                .ToSafeTask();
        }

        public Task DeleteMailAsync(Mail mail)
        {
            return this.GetConnectionAsync()
                .Then(t => t.Result.Send("deleteMail", mail.Id))
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
                        var id = message.GetString(i++);
                        var channel = message.GetString(i++);
                        var title = message.GetString(i++);
                        var body = message.GetString(i++);
                        var publishDate =  DateTime.ParseExact(message.GetString(i++), "g", CultureInfo.InvariantCulture);
                        var roomId = message.GetString(i++);
                        var imageUrl = message.GetString(i++);

                        notifications.Add(new Notification(id, channel, title, body, publishDate, roomId, imageUrl));
                    }
                    return notifications.ToArray();
                })
                .ToSafeTask();
        }

        public Task DismissNotificationAsync(Notification notification)
        {
            return this.GetConnectionAsync()
                .Then(t => t.Result.Send("dismissNotification", notification.Id))
                .ToSafeTask();
        }

        public Task SetTimeZoneAsync(TimeZoneInfo timeZone)
        {
            return this.GetConnectionAsync()
            .Then(t => t.Result.Send("timezone", timeZone.BaseUtcOffset.TotalHours))
                .ToSafeTask();
        }


        // TODO GetShop
        // GetCampaigns
        // useEnergy, useAllEnergy, useGems
        //getCrew getMyCrews createCrew getCrewInvites blockCrewInvites blockAllCrewInvites
        // getFriends getPending getInvitesToMe getBlockedUsers createInvite answerInvite deleteInvite blockUserInvites getBlockStatus blockAllInvites deleteFriend GetOnlineStatus
        // finishTutorial acceptTerms checkUsername setUsername changeUsername
    }

    public class CampaignData
    {
        
    }
}
