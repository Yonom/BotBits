using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using PlayerIOClient;

namespace BotBits
{
    public static class ConnectionManagerExtensions
    {
        [Pure]
        public static T GuestLogin<T>(this IConnectionManager<T> connectionManager)
        {
            return GuestLoginAsync(connectionManager).GetResultEx();
        }

        [Pure]
        public static T EmailLogin<T>(this IConnectionManager<T> connectionManager, string email, string password)
        {
            return EmailLoginAsync(connectionManager, email, password).GetResultEx();
        }

        [Pure]
        public static T FacebookLogin<T>(this IConnectionManager<T> connectionManager, string token)
        {
            return FacebookLoginAsync(connectionManager, token).GetResultEx();
        }

        [Pure]
        public static T KongregateLogin<T>(this IConnectionManager<T> connectionManager, string userId, string token)
        {
            return KongregateLoginAsync(connectionManager, userId, token).GetResultEx();
        }

        [Pure]
        public static T ArmorGamesLogin<T>(this IConnectionManager<T> connectionManager, string userId, string token)
        {
            return ArmorGamesLoginAsync(connectionManager, userId, token).GetResultEx();
        }

        [Pure]
        public static Task<T> GuestLoginAsync<T>(this IConnectionManager<T> connectionManager)
        {
            return ConnectionUtils.GuestLoginAsync()
                .Then(task => connectionManager.WithClient(task.Result))
                .ToSafeTask();
        }

        [Pure]
        public static Task<T> EmailLoginAsync<T>(this IConnectionManager<T> connectionManager, string email, string password)
        {
            return PlayerIO.QuickConnect.SimpleConnectAsync(ConnectionUtils.GameId, email, password, null)
                .Then(task => connectionManager.WithClient(task.Result))
                .ToSafeTask();
        }

        [Pure]
        public static Task<T> FacebookLoginAsync<T>(this IConnectionManager<T> connectionManager, string token)
        {
            return PlayerIO.QuickConnect.FacebookOAuthConnectAsync(ConnectionUtils.GameId, token, null, null)
                .Then(task => connectionManager.WithClient(task.Result))
                .ToSafeTask();
        }

        [Pure]
        public static Task<T> KongregateLoginAsync<T>(this IConnectionManager<T> connectionManager, string userId, string token)
        {
            return PlayerIO.QuickConnect.KongregateConnectAsync(ConnectionUtils.GameId, userId, token, null)
                .Then(task => connectionManager.WithClient(task.Result))
                .ToSafeTask();
        }

        [Pure]
        public static Task<T> ArmorGamesLoginAsync<T>(this IConnectionManager<T> connectionManager, string userId, string token)
        {
            return ConnectionUtils.ArmorGamesRoomLoginAsync(userId, token)
                .Then(task => connectionManager.WithClient(task.Result))
                .ToSafeTask();
        }
    }
}
