using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using PlayerIOClient;

namespace BotBits
{
    public static class PlayerIOGameExtensions
    {
        [Pure]
        public static T GuestLogin<T>(this IPlayerIOGame<T> playerIOGame)
        {
            return GuestLoginAsync(playerIOGame).GetResultEx();
        }

        [Pure]
        public static T EmailLogin<T>(this IPlayerIOGame<T> playerIOGame, string email, string password)
        {
            return EmailLoginAsync(playerIOGame, email, password).GetResultEx();
        }

        [Pure]
        public static T FacebookLogin<T>(this IPlayerIOGame<T> playerIOGame, string token)
        {
            return FacebookLoginAsync(playerIOGame, token).GetResultEx();
        }

        [Pure]
        public static T KongregateLogin<T>(this IPlayerIOGame<T> playerIOGame, string userId, string token)
        {
            return KongregateLoginAsync(playerIOGame, userId, token).GetResultEx();
        }

        [Pure]
        public static T ArmorGamesLogin<T>(this IPlayerIOGame<T> playerIOGame, string userId, string token)
        {
            return ArmorGamesLoginAsync(playerIOGame, userId, token).GetResultEx();
        }

        [Pure]
        public static Task<T> GuestLoginAsync<T>(this IPlayerIOGame<T> playerIOGame)
        {
            return ConnectionUtils.GuestLoginAsync(playerIOGame.GameId)
                .Then(task => playerIOGame.ConnectionManager.WithClient(task.Result))
                .ToSafeTask();
        }

        [Pure]
        public static Task<T> EmailLoginAsync<T>(this IPlayerIOGame<T> playerIOGame, string email, string password)
        {
            return PlayerIO.QuickConnect.SimpleConnectAsync(playerIOGame.GameId, email, password, null)
                .Then(task => playerIOGame.ConnectionManager.WithClient(task.Result))
                .ToSafeTask();
        }

        [Pure]
        public static Task<T> FacebookLoginAsync<T>(this IPlayerIOGame<T> playerIOGame, string token)
        {
            return PlayerIO.QuickConnect.FacebookOAuthConnectAsync(playerIOGame.GameId, token, null, null)
                .Then(task => playerIOGame.ConnectionManager.WithClient(task.Result))
                .ToSafeTask();
        }

        [Pure]
        public static Task<T> KongregateLoginAsync<T>(this IPlayerIOGame<T> playerIOGame, string userId, string token)
        {
            return PlayerIO.QuickConnect.KongregateConnectAsync(playerIOGame.GameId, userId, token, null)
                .Then(task => playerIOGame.ConnectionManager.WithClient(task.Result))
                .ToSafeTask();
        }

        [Pure]
        public static Task<T> ArmorGamesLoginAsync<T>(this IPlayerIOGame<T> playerIOGame, string userId, string token)
        {
            return ConnectionUtils.ArmorGamesRoomLoginAsync(playerIOGame.GameId, userId, token)
                .Then(task => playerIOGame.ConnectionManager.WithClient(task.Result))
                .ToSafeTask();
        }
    }
}
