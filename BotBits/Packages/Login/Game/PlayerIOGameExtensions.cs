using System.Threading.Tasks;
using JetBrains.Annotations;
using PlayerIOClient;

namespace BotBits
{
    public static class PlayerIOGameExtensions
    {
        [Pure]
        public static T AsGuest<T>(this IPlayerIOGame<T> playerIOGame)
        {
            return AsGuestAsync(playerIOGame).GetResultEx();
        }

        [Pure]
        public static T WithEmail<T>(this IPlayerIOGame<T> playerIOGame, string email, string password)
        {
            return WithEmailAsync(playerIOGame, email, password).GetResultEx();
        }

        [Pure]
        public static T WithFacebook<T>(this IPlayerIOGame<T> playerIOGame, string token)
        {
            return WithFacebookAsync(playerIOGame, token).GetResultEx();
        }

        [Pure]
        public static T WithKongregate<T>(this IPlayerIOGame<T> playerIOGame, string userId, string token)
        {
            return WithKongregateAsync(playerIOGame, userId, token).GetResultEx();
        }

        [Pure]
        public static T WithArmorGames<T>(this IPlayerIOGame<T> playerIOGame, string userId, string token)
        {
            return WithArmorGamesAsync(playerIOGame, userId, token).GetResultEx();
        }

        [Pure]
        public static Task<T> AsGuestAsync<T>(this IPlayerIOGame<T> playerIOGame)
        {
            return ConnectionUtils.GuestLoginAsync(playerIOGame.GameId)
                .Then(task => playerIOGame.ConnectionManager.WithClient(task.Result))
                .ToSafeTask();
        }

        [Pure]
        public static Task<T> WithEmailAsync<T>(this IPlayerIOGame<T> playerIOGame, string email, string password)
        {
            return PlayerIO.QuickConnect.SimpleConnectAsync(playerIOGame.GameId, email, password, null)
                .Then(task => playerIOGame.ConnectionManager.WithClient(task.Result))
                .ToSafeTask();
        }

        [Pure]
        public static Task<T> WithFacebookAsync<T>(this IPlayerIOGame<T> playerIOGame, string token)
        {
            return PlayerIO.QuickConnect.FacebookOAuthConnectAsync(playerIOGame.GameId, token, null, null)
                .Then(task => playerIOGame.ConnectionManager.WithClient(task.Result))
                .ToSafeTask();
        }

        [Pure]
        public static Task<T> WithKongregateAsync<T>(this IPlayerIOGame<T> playerIOGame, string userId, string token)
        {
            return PlayerIO.QuickConnect.KongregateConnectAsync(playerIOGame.GameId, userId, token, null)
                .Then(task => playerIOGame.ConnectionManager.WithClient(task.Result))
                .ToSafeTask();
        }

        [Pure]
        public static Task<T> WithArmorGamesAsync<T>(this IPlayerIOGame<T> playerIOGame, string userId, string token)
        {
            return ConnectionUtils.ArmorGamesRoomLoginAsync(playerIOGame.GameId, userId, token)
                .Then(task => playerIOGame.ConnectionManager.WithClient(task.Result))
                .ToSafeTask();
        }
    }
}