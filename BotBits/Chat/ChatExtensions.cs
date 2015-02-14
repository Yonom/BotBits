using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;

namespace BotBits
{
    public static class ChatExtensions
    {
        public static void GiveEdit(this IChat chat, string username)
        {
            chat.Say("/giveedit {0}", username);
        }

        public static void RemoveEdit(this IChat chat, string username)
        {
            chat.Say("/removeedit {0}", username);
        }

        public static void Teleport(this IChat chat, string username)
        {
            chat.Say("/teleport {0}", username);
        }

        public static void Teleport(this IChat chat, string username, int x, int y)
        {
            chat.Say("/teleport {0} {1} {2}", username, x, y);
        }

        public static void Kick(this IChat chat, string username)
        {
            chat.Say("/kick {0}", username);
        }

        public static void Kick(this IChat chat, string username, string reason)
        {
            chat.Say("/kick {0} {1}", username, reason);
        }

        public static void KickGuests(this IChat chat)
        {
            chat.Say("/kickguests");
        }

        public static void Kill(this IChat chat, string username)
        {
            chat.Say("/kill {0}", username);
        }

        public static void KillAll(this IChat chat)
        {
            chat.Say("/killemall");
        }

        public static void Mute(this IChat chat, string username)
        {
            chat.Say("/mute {0}", username);
        }

        public static void Unmute(this IChat chat, string username)
        {
            chat.Say("/unmute {0}", username);
        }

        public static void ReportAbuse(this IChat chat, string username, string reason)
        {
            chat.Say("/reportabuse {0} {1}", username, reason);
        }

        public static void Reset(this IChat chat)
        {
            chat.Say("/reset");
        }

        public static void Respawn(this IChat chat)
        {
            chat.Say("/respawn");
        }

        public static void RespawnAll(this IChat chat)
        {
            chat.Say("/respawnall");
        }

        public static void PotionsOn(this IChat chat, params string[] potions)
        {
            chat.Say("/potionson  {0}", String.Join(" ", potions));
        }

        public static void PotionsOn(this IChat chat, params int[] potions)
        {
            chat.Say("/potionson  {0}", String.Join(" ", potions));
        }

        public static void PotionsOn(this IChat chat, params Potion[] potions)
        {
            chat.Say("/potionson {0}", String.Join(" ", potions.Cast<int>()));
        }

        public static void PotionsOff(this IChat chat, params string[] potions)
        {
            chat.Say("/potionsoff {0}", String.Join(" ", potions));
        }

        public static void PotionsOff(this IChat chat, params int[] potions)
        {
            chat.Say("/potionsoff {0}", String.Join(" ", potions));
        }

        public static void PotionsOff(this IChat chat, params Potion[] potions)
        {
            chat.Say("/potionsoff {0}", String.Join(" ", potions.Cast<int>()));
        }

        public static void ChangeVisibility(this IChat chat, bool visible)
        {
            chat.Say("/visible {0}", visible);
        }

        public static void LoadLevel(this IChat chat)
        {
            chat.Say("/loadlevel");
        }

        public static void SetBackgroundColor(this IChat chat, string color)
        {
            chat.Say("/bgcolor {0}", color);
        }

        public static void SetBackgroundColor(this IChat chat, byte r, byte g, byte b)
        {
            chat.Say("/bgcolor #{0:x2}{1:x2}{2:x2}", r, g, b);
        }

        public static void ListPortals(this IChat chat)
        {
            chat.Say("/listportals");
        }

        public static void GetBlockPlacer(this IChat chat)
        {
            chat.Say("/getblockplacer");
        }

        public static void GetPosition(this IChat chat)
        {
            chat.Say("/getpos");
        }

        public static void PrivateMessage(this IChat chat, string target, string message)
        {
            chat.Say("/pm {0} {1}", target, message);
        }

        public static void HideLobby(this IChat chat, bool hidden)
        {
            chat.Say("/hidelobby {0}", hidden);
        }

        [StringFormatMethod("msg")]
        public static void Say(this IChat chat, string msg, params object[] args)
        {
            chat.Say(String.Format(msg, args));
        }

        [StringFormatMethod("reason")]
        public static void Kick(this IChat chat, string username, string reason, params object[] args)
        {
            chat.Kick(username, String.Format(reason, args));
        }

        [StringFormatMethod("reason")]
        public static void Kick(this IChat chat, Player player, string reason, params object[] args)
        {
            chat.Kick(player.Username, reason, args);
        }

        [StringFormatMethod("reason")]
        public static void ReportAbuse(this IChat chat, string username, string reason, params object[] args)
        {
            chat.ReportAbuse(username, String.Format(reason, args));
        }

        [StringFormatMethod("reason")]
        public static void ReportAbuse(this IChat chat, Player player, string reason, params object[] args)
        {
            chat.ReportAbuse(player.Username, reason, args);
        }

        public static void GiveEdit(this IChat chat, Player player)
        {
            chat.GiveEdit(player.Username);
        }

        public static void RemoveEdit(this IChat chat, Player player)
        {
            chat.RemoveEdit(player.Username);
        }

        public static void Teleport(this IChat chat, Player player)
        {
            chat.Teleport(player.Username);
        }

        public static void Teleport(this IChat chat, Player player, int x, int y)
        {
            chat.Teleport(player.Username, x, y);
        }

        public static void Teleport(this IChat chat, string username, Point point)
        {
            chat.Teleport(username, point.X + 1, point.Y + 1);
        }

        public static void Teleport(this IChat chat, Player player, Point point)
        {
            chat.Teleport(player.Username, point.X + 1, point.Y + 1);
        }

        public static void Kick(this IChat chat, Player player)
        {
            chat.Kick(player.Username);
        }

        public static void Kick(this IChat chat, Player player, string reason)
        {
            chat.Kick(player.Username, reason);
        }

        public static void Kill(this IChat chat, Player player)
        {
            chat.Kill(player.Username);
        }

        public static void Mute(this IChat chat, Player player)
        {
            chat.Mute(player.Username);
        }

        public static void Unmute(this IChat chat, Player player)
        {
            chat.Unmute(player.Username);
        }

        public static void ReportAbuse(this IChat chat, Player player, string reason)
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
