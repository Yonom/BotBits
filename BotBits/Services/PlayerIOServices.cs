﻿using System;
using System.Threading.Tasks;
using PlayerIOClient;

namespace BotBits
{
    public static class PlayerIOServices
    {
        public const string GameId = "everybody-edits-su9rn58o40itdbnw69plyw";

        private static Client _defaultClient;

        public static Client DefaultClient
        {
            get
            {
                if (RefreshRequired)
                    throw new InvalidOperationException("No DefaultClient has been set. Call PlayerIOServices.RefreshDefaultClient() first.");
                return _defaultClient;
            }
            set => _defaultClient = value;
        }

        public static bool UseSsl
        {
            get => PlayerIO.UseSecureApiRequests;
            set => PlayerIO.UseSecureApiRequests = value;
        }

        public static bool RefreshRequired => _defaultClient == null;

        public static Task RefreshDefaultClientAsync()
        {
            return LoginUtils.GuestLoginAsync(GameId)
                .Then(t => DefaultClient = t.Result)
                .ToSafeTask();
        }

        public static void RefreshDefaultClient()
        {
            RefreshDefaultClientAsync().WaitEx();
        }
    }
}