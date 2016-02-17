using JetBrains.Annotations;

namespace BotBits
{
    /// <summary>
    ///     ChatExtensions contains functions to execute commands in game.
    /// </summary>
    public static class ChatExtensions
    {
        /// <summary>
        ///     Sets the team of the given player (/setteam &lt;username&gt; &lt;team&gt;).
        /// </summary>
        /// <param name="chat">The chat.</param>
        /// <param name="username">The username.</param>
        /// <param name="team">The team.</param>
        public static void SetTeam(this IChat chat, string username, Team team)
        {
            chat.Say("/setteam {0} {1}", username, team);
        }

        /// <summary>
        ///     Clears the effects a player has  (/cleareffects &lt;username&gt;).
        /// </summary>
        /// <param name="chat">The chat.</param>
        /// <param name="username">The username.</param>
        public static void ClearEffects(this IChat chat, string username)
        {
            chat.Say("/cleareffects {0}", username);
        }

        /// <summary>
        ///     Forces the player out / into god mode (/forcefly &lt;username&gt; &lt;flying&gt;).
        /// </summary>
        /// <param name="chat">The chat.</param>
        /// <param name="username">The username.</param>
        /// <param name="flying">if set to <c>true</c> the player will be forced into flying.</param>
        public static void ForceFly(this IChat chat, string username, bool flying)
        {
            chat.Say("/forcefly {0} {1}", username, flying);
        }


        /// <summary>
        ///     Gives edit to the specified username  (/giveedit &lt;username&gt;).
        /// </summary>
        /// <param name="chat">The chat.</param>
        /// <param name="username">The username.</param>
        public static void GiveEdit(this IChat chat, string username)
        {
            chat.Say("/giveedit {0}", username);
        }

        /// <summary>
        ///     Removes edit from the specified username (/removeedit &lt;username&gt;).
        /// </summary>
        /// <param name="chat">The chat.</param>
        /// <param name="username">The username.</param>
        public static void RemoveEdit(this IChat chat, string username)
        {
            chat.Say("/removeedit {0}", username);
        }

        /// <summary>
        ///     Teleports the specified username.
        /// </summary>
        /// <param name="chat">The chat.</param>
        /// <param name="username">The username.</param>
        public static void Teleport(this IChat chat, string username)
        {
            chat.Say("/teleport {0}", username);
        }

        /// <summary>
        ///     Teleports the specified username. (/teleport &lt;username&gt; &lt;x&gt; &lt;y&gt;).
        /// </summary>
        /// <param name="chat">The chat.</param>
        /// <param name="username">The username.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public static void Teleport(this IChat chat, string username, int x, int y)
        {
            chat.Say("/teleport {0} {1} {2}", username, x, y);
        }

        /// <summary>
        ///     Kicks the specified username (/kick &lt;username&gt;).
        /// </summary>
        /// <param name="chat">The chat.</param>
        /// <param name="username">The username.</param>
        public static void Kick(this IChat chat, string username)
        {
            chat.Say("/kick {0}", username);
        }

        /// <summary>
        ///     Kicks the specified username (/kick &lt;username&gt; &lt;reason&gt;).
        /// </summary>
        /// <param name="chat">The chat.</param>
        /// <param name="username">The username.</param>
        /// <param name="reason">The reason.</param>
        public static void Kick(this IChat chat, string username, string reason)
        {
            chat.Say("/kick {0} {1}", username, reason);
        }

        /// <summary>
        ///     Silently kicks all guests (/kickguests).
        /// </summary>
        public static void KickGuests(this IChat chat)
        {
            chat.Say("/kickguests");
        }

        /// <summary>
        ///     Kills the specified username. (/kill &lt;username&gt;).
        /// </summary>
        /// <param name="chat">The chat.</param>
        /// <param name="username">The username.</param>
        public static void Kill(this IChat chat, string username)
        {
            chat.Say("/kill {0}", username);
        }

        /// <summary>
        ///     Kills all the users in the world (/killall).
        /// </summary>
        public static void KillAll(this IChat chat)
        {
            chat.Say("/killall");
        }

        /// <summary>
        ///     Mutes the specified username. (/mute &lt;username&gt;).
        /// </summary>
        /// <param name="chat">The chat.</param>
        /// <param name="username">The username.</param>
        public static void Mute(this IChat chat, string username)
        {
            chat.Say("/mute {0}", username);
        }

        /// <summary>
        ///     Unmutes the specified username. (/unmute &lt;username&gt;).
        /// </summary>
        /// <param name="chat">The chat.</param>
        /// <param name="username">The username.</param>
        public static void Unmute(this IChat chat, string username)
        {
            chat.Say("/unmute {0}", username);
        }

        /// <summary>
        ///     Reports the specified user with the given reason (/reportabuse &lt;username&gt; &lt;reason&gt;).
        /// </summary>
        /// <param name="chat">The chat.</param>
        /// <param name="username">The username.</param>
        /// <param name="reason">The reason.</param>
        public static void ReportAbuse(this IChat chat, string username, string reason)
        {
            chat.Say("/reportabuse {0} {1}", username, reason);
        }

        /// <summary>
        ///     Enables god mode of the specified username (/givegod &lt;username&gt;).
        /// </summary>
        /// <param name="chat">The chat.</param>
        /// <param name="username">The username.</param>
        public static void GiveGod(this IChat chat, string username)
        {
            chat.Say("/givegod {0}", username);
        }

        /// <summary>
        ///     Disables god mode of the specified username (/removegod &lt;username&gt;).
        /// </summary>
        /// <param name="chat">The chat.</param>
        /// <param name="username">The username.</param>
        public static void RemoveGod(this IChat chat, string username)
        {
            chat.Say("/removegod {0}", username);
        }

        /// <summary>
        ///     Gives the crown to the specified username (/givecrown &lt;username&gt;).
        /// </summary>
        /// <param name="chat">Chat.</param>
        /// <param name="username">Username.</param>
        public static void GiveCrown(this IChat chat, string username)
        {
            chat.Say("/givecrown {0}", username);
        }

        /// <summary>
        ///     Removes the crown from it's owner (/removecrown).
        /// </summary>
        /// <param name="chat">Chat.</param>
        public static void RemoveCrown(this IChat chat)
        {
            chat.Say("/removecrown");
        }

        /// <summary>
        ///     Resets the users' position (/reset &lt;username&gt;).
        /// </summary>
        public static void Reset(this IChat chat, string username)
        {
            chat.Say("/reset {0}", username);
        }

        /// <summary>
        ///     Resets all the users' positions (/resetall).
        /// </summary>
        public static void ResetAll(this IChat chat)
        {
            chat.Say("/resetall");
        }

        /// <summary>
        ///     Respawns all users in the world (/respawnall).
        /// </summary>
        public static void RespawnAll(this IChat chat)
        {
            chat.Say("/respawnall");
        }

        /// <summary>
        ///     Loads the level to the most recent saved version (/loadlevel).
        /// </summary>
        public static void LoadLevel(this IChat chat)
        {
            chat.Say("/loadlevel");
        }

        /// <summary>
        ///     Sets the color of the background (/bgcolor &lt;color&gt;).
        /// </summary>
        /// <param name="chat">The chat.</param>
        /// <param name="color">The color.</param>
        public static void SetBackgroundColor(this IChat chat, string color)
        {
            chat.Say("/bgcolor {0}", color);
        }

        /// <summary>
        ///     Sets the color of the background (/bgcolor #rrggbb).
        /// </summary>
        /// <param name="chat">The chat.</param>
        /// <param name="r">The red portion of the color.</param>
        /// <param name="g">The green portion of the color.</param>
        /// <param name="b">The blue portion of the color.</param>
        public static void SetBackgroundColor(this IChat chat, byte r, byte g, byte b)
        {
            chat.Say("/bgcolor #{0:x2}{1:x2}{2:x2}", r, g, b);
        }

        /// <summary>
        ///     Lists the portals (/listportals).
        /// </summary>
        public static void ListPortals(this IChat chat)
        {
            chat.Say("/listportals");
        }

        /// <summary>
        ///     Clears the map (/clear)
        /// </summary>
        public static void Clear(this IChat chat)
        {
            chat.Say("/clear");
        }

        /// <summary>
        ///     Gets the block placer (/getblockplacer).
        /// </summary>
        public static void GetBlockPlacer(this IChat chat)
        {
            chat.Say("/getblockplacer");
        }

        /// <summary>
        ///     Gets the position of the bot (/getpos).
        /// </summary>
        public static void GetPosition(this IChat chat)
        {
            chat.Say("/getpos");
        }

        /// <summary>
        ///     Sends a private message (/pm &lt;target&gt; &lt;message&gt;)
        /// </summary>
        /// <param name="chat">The chat.</param>
        /// <param name="target">The target.</param>
        /// <param name="message">The message.</param>
        public static void PrivateMessage(this IChat chat, string target, string message)
        {
            chat.Say("/pm {0} {1}", target, message);
        }


        /// <summary>
        ///     Sends a private message (/pm &lt;target&gt; &lt;message&gt;)
        /// </summary>
        /// <param name="chat">The chat.</param>
        /// <param name="target">The target.</param>
        /// <param name="message">The message.</param>
        public static void PrivateMessage(this IChat chat, Player target, string message)
        {
            chat.PrivateMessage(target.Username, message);
        }


        /// <summary>
        ///     Sends a private message (/pm &lt;target&gt; &lt;message&gt;)
        /// </summary>
        /// <param name="chat">The chat.</param>
        /// <param name="target">The target.</param>
        /// <param name="message">The message.</param>
        /// <param name="args">The arguments.</param>
        [StringFormatMethod("args")]
        public static void PrivateMessage(this IChat chat, string target, string message, params object[] args)
        {
            chat.PrivateMessage(target, string.Format(message, args));
        }

        /// <summary>
        ///     Says the specified message.
        /// </summary>
        /// <param name="chat">The chat.</param>
        /// <param name="msg">The message.</param>
        /// <param name="args">The arguments.</param>
        [StringFormatMethod("msg")]
        public static void Say(this IChat chat, string msg, params object[] args)
        {
            // ReSharper disable once RedundantStringFormatCall
            chat.Say(string.Format(msg, args));
        }

        /// <summary>
        ///     Kicks the specified username (/kick &lt;username&gt; &lt;reason&gt;).
        /// </summary>
        /// <param name="chat">The chat.</param>
        /// <param name="username">The username.</param>
        /// <param name="reason">The reason.</param>
        /// <param name="args">The arguments.</param>
        [StringFormatMethod("reason")]
        public static void Kick(this IChat chat, string username, string reason, params object[] args)
        {
            chat.Kick(username, string.Format(reason, args));
        }

        /// <summary>
        ///     Reports the specified user with the given reason (/reportabuse &lt;username&gt; &lt;reason&gt;).
        /// </summary>
        /// <param name="chat">The chat.</param>
        /// <param name="username">The username.</param>
        /// <param name="reason">The reason.</param>
        /// <param name="args">The arguments.</param>
        [StringFormatMethod("reason")]
        public static void ReportAbuse(this IChat chat, string username, string reason, params object[] args)
        {
            chat.ReportAbuse(username, string.Format(reason, args));
        }

        /// <summary>
        ///     Teleports the specified username (/teleport &lt;username&gt; &lt;point.X+1&gt; &lt;point.Y+1&gt;).
        /// </summary>
        /// <param name="chat">The chat.</param>
        /// <param name="username">The username.</param>
        /// <param name="point">The point.</param>
        public static void Teleport(this IChat chat, string username, Point point)
        {
            chat.Teleport(username, point.X, point.Y);
        }

        /// <summary>
        ///     Removes the background color (/bgcolor none).
        /// </summary>
        /// <param name="chat">The chat.</param>
        public static void RemoveBackgroundColor(this Chat chat)
        {
            chat.SetBackgroundColor("none");
        }
    }
}