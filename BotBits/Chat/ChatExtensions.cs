using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BotBits.Annotations;

namespace BotBits
{
    public static class ChatExtensions
    {

        [StringFormatMethod("msg")]
        public static void Say(this Chat chat, string msg, params object[] args)
        {
            chat.Say(String.Format(msg, args));
        }

        [StringFormatMethod("reason")]
        public static void Kick(this Chat chat, string username, string reason, params object[] args)
        {
            chat.Kick(username, String.Format(reason, args));
        }

        [StringFormatMethod("reason")]
        public static void Kick(this Chat chat, Player player, string reason, params object[] args)
        {
            chat.Kick(player.Username, reason, args);
        }

        [StringFormatMethod("reason")]
        public static void ReportAbuse(this Chat chat, string username, string reason, params object[] args)
        {
            chat.ReportAbuse(username, String.Format(reason, args));
        }

        [StringFormatMethod("reason")]
        public static void ReportAbuse(this Chat chat, Player player, string reason, params object[] args)
        {
            chat.ReportAbuse(player.Username, reason, args);
        }

        public static void GiveEdit(this Chat chat, Player player)
        {
            chat.GiveEdit(player.Username);
        }

        public static void RemoveEdit(this Chat chat, Player player)
        {
            chat.RemoveEdit(player.Username);
        }

        public static void Teleport(this Chat chat, Player player)
        {
            chat.Teleport(player.Username);
        }

        public static void Teleport(this Chat chat, Player player, int x, int y)
        {
            chat.Teleport(player.Username, x, y);
        }

        public static void Teleport(this Chat chat, string username, Point point)
        {
            chat.Teleport(username, point.X + 1, point.Y + 1);
        }

        public static void Teleport(this Chat chat, Player player, Point point)
        {
            chat.Teleport(player.Username, point.X + 1, point.Y + 1);
        }

        public static void Kick(this Chat chat, Player player)
        {
            chat.Kick(player.Username);
        }

        public static void Kick(this Chat chat, Player player, string reason)
        {
            chat.Kick(player.Username, reason);
        }

        public static void Kill(this Chat chat, Player player)
        {
            chat.Kill(player.Username);
        }

        public static void Mute(this Chat chat, Player player)
        {
            chat.Mute(player.Username);
        }

        public static void Unmute(this Chat chat, Player player)
        {
            chat.Unmute(player.Username);
        }

        public static void ReportAbuse(this Chat chat, Player player, string reason)
        {
            chat.ReportAbuse(player.Username, reason);
        }

        public static void RemoveBackgroundColor(this Chat chat)
        {
            chat.SetBackgroundColor("none");
        }
        
      //  TODO: async save
    }
}
