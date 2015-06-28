using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using BotBits.Events;

namespace BotBits
{
    public sealed class Players : EventListenerPackage<Players>, IEnumerable<Player>
    {
        private readonly Dictionary<int, Player> _players = new Dictionary<int, Player>();
        private Player _crownPlayer = Player.Nobody;
        private Player _ownPlayer = Player.Nobody;

        public Player OwnPlayer
        {
            get { return this._ownPlayer; }
            private set { this._ownPlayer = value; }
        }

        public Player CrownPlayer
        {
            get { return this._crownPlayer; }
            private set { this._crownPlayer = value; }
        }

        public int Count
        {
            get
            {
                lock (this._players) 
                    return this._players.Count;
            }
        }

        public Player this[int userId]
        {
            get
            {
                if (userId == Player.Nobody.UserId)
                    return Player.Nobody;

                lock (this._players)
                    return this._players[userId];
            }
        }

        [Obsolete("Invalid to use \"new\" on this class. Use the static .Of(botBits) method instead.", true)]
        public Players()
        {
        }

        public IEnumerator<Player> GetEnumerator()
        {
            return ((IEnumerable<Player>)this.GetPlayers()).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        [Pure]
        public bool Contains(int userId)
        {
            lock (this._players)
                return this._players.ContainsKey(userId);
        }

        [Pure]
        public Player[] GetPlayers()
        {
            lock (this._players)
                return this._players.Values.Where(p => p.Connected).ToArray();
        }

        [Pure]
        public Player[] FromUsername(string username)
        {
            lock (this._players)
                return this._players.Values.Where(p => p.Username == username).ToArray();
        }

        internal Player AddPlayer(int userId)
        {
            lock (this._players)
            {
                var player = new Player(this, userId);
                this._players.Add(userId, player);
                return player;
            }
        }

        [EventListener(EventPriority.High)]
        private void OnInit(InitEvent e)
        {
            this.OwnPlayer = e.Player;
            this.OwnPlayer.Connected = true;
            this.OwnPlayer.Username = e.Username;
            this.OwnPlayer.Smiley = e.Smiley;
            this.OwnPlayer.Aura = e.Aura;
            this.OwnPlayer.ChatColor = e.ChatColor;
            this.OwnPlayer.X = e.SpawnX;
            this.OwnPlayer.Y = e.SpawnY;
        }

        [EventListener(EventPriority.High)]
        private void OnAdd(JoinEvent e)
        {
            Player p = e.Player;
            p.Connected = true;
            p.Username = e.Username;
            p.Smiley = e.Smiley;
            p.Aura = e.Aura;
            p.HasChat = e.HasChat;
            p.GodMode = e.God;
            p.AdminMode = e.Admin;
            p.ModMode = e.Mod;
            p.Friend = e.Friend;
            p.GoldCoins = e.Coins;
            p.BlueCoins = e.BlueCoins;
            p.X = e.X;
            p.Y = e.Y;
            p.ClubMember = e.ClubMember;
            p.ChatColor = e.ChatColor;
            p.Team = e.Team;
        }

        [EventListener(EventPriority.High)]
        private void OnCrown(CrownEvent e)
        {
            this.CrownPlayer = e.Player;
        }

        [EventListener(EventPriority.High)]
        private void OnLeave(LeaveEvent e)
        {
            Player leftPlayer;
            lock (this._players)
                if (this._players.TryGetValue(e.Player.UserId, out leftPlayer))
                {
                    this._players.Remove(e.Player.UserId);
                    leftPlayer.Connected = false;
                }
        }

        [EventListener(EventPriority.High)]
        private void OnCoin(CoinEvent e)
        {
            Player p = e.Player;

            if (p.GoldCoins != e.GoldCoins)
            {
                p.GoldCoins = e.GoldCoins;
                new GoldCoinEvent(p, p.GoldCoins)
                    .RaiseIn(this.BotBits);
            } 
            if (p.BlueCoins != e.BlueCoins)
            {
                p.BlueCoins = e.BlueCoins;
                new BlueCoinEvent(p, p.BlueCoins)
                    .RaiseIn(this.BotBits);
            }
        }

        [EventListener(EventPriority.High)]
        private void OnSmiley(SmileyEvent e)
        {
            Player p = e.Player;
            p.Smiley = e.Smiley;
        }

        [EventListener(EventPriority.High)]
        private void OnMove(MoveEvent e)
        {
            Player p = e.Player;
            //p.GoldCoins = e.Coins;
            p.Horizontal = e.Horizontal;
            p.Vertical = e.Vertical;
            p.ModifierX = e.ModifierX;
            p.ModifierY = e.ModifierY;
            p.SpeedX = e.SpeedX;
            p.SpeedY = e.SpeedY;
            p.X = e.X;
            p.Y = e.Y;
            p.Dead = false;
            p.SpaceDown = e.SpaceDown;
        }

        [EventListener(EventPriority.High)]
        private void OnGodMode(GodModeEvent e)
        {
            Player p = e.Player;
            p.GodMode = e.God;

            if (!p.ModMode && !p.AdminMode)
            {
                new FlyEvent(p, p.Flying)
                    .RaiseIn(this.BotBits);
            }
        }

        [EventListener(EventPriority.High)]
        private void OnAdminMode(AdminModeEvent e)
        {
            Player p = e.Player;
            p.AdminMode = e.Admin; 
            
            if (!p.ModMode && !p.GodMode)
            {
                new FlyEvent(p, p.Flying)
                    .RaiseIn(this.BotBits);
            }
        }

        [EventListener(EventPriority.High)]
        private void OnModMode(ModModeEvent e)
        {
            Player p = e.Player;
            p.ModMode = e.Mod;

            if (!p.GodMode && !p.AdminMode)
            {
                new FlyEvent(p, p.Flying)
                    .RaiseIn(this.BotBits);
            }
        }

        [EventListener(EventPriority.High)]
        private void OnSilverCrown(SilverCrownEvent e)
        {
            Player p = e.Player;
            p.HasSilverCrown = true;
        }

        [EventListener(EventPriority.High)]
        private void OnEffect(EffectEvent e)
        {
            Player p = e.Player;

            if (e.Enabled)
            {
                var effect = new ActiveEffect(e.Effect, e.TimeLeft, e.Duration);
                p.AddEffect(effect);
            }
            else
            {
                p.RemoveEffect(e.Effect);
            }
        }

        [EventListener(EventPriority.High)]
        private void OnAura(AuraEvent e)
        {
            Player p = e.Player;
            p.Aura = e.Aura;
        }

        [EventListener(EventPriority.High)]
        private void OnTeam(TeamEvent e)
        {
            Player p = e.Player;
            p.Team = e.Team;
        }

        [EventListener(EventPriority.High)]
        private void OnWootUp(WootUpEvent e)
        {
            Player p = e.Player;
            p.HasWooted = true;
        }

        [EventListener(EventPriority.High)]
        private void OnKill(KillEvent e)
        {
            Player p = e.Player;
            p.Dead = true;
        }

        [EventListener(EventPriority.High)]
        private void OnSwitchInit(PurpleSwitchInitEvent e)
        {
            Player p = e.Player;
            for (var i = 0; i < e.PurpleSwitches.Length; i++)
            {
                if (e.PurpleSwitches[i] == 0) continue;

                p.AddSwitch(i);
                new PurpleSwitchEvent(p, i, true)
                    .RaiseIn(this.BotBits);
            }
        }

        [EventListener(EventPriority.High)]
        private void OnSwitchUpdate(PurpleSwitchUpdateEvent e)
        {
            Player p = e.Player;
            var enabled = e.Enabled != 0;
            if (enabled)
                p.AddSwitch(e.SwitchId);
            else
                p.RemoveSwitch(e.SwitchId);

            new PurpleSwitchEvent(p, e.SwitchId, enabled)
                .RaiseIn(this.BotBits);
        }

        [EventListener(EventPriority.High)]
        private void OnTeleportUser(TeleportEvent e)
        {
            Player p = e.Player;
            p.X = e.X;
            p.Y = e.Y;
            p.Dead = false;
        }

        [EventListener(EventPriority.High)]
        private void OnMultiRespawn(MultiRespawnEvent e)
        {
            foreach (var tele in e.Coordinates)
            {
                Player p = tele.Key;
                Point location = tele.Value;

                p.X = location.X;
                p.Y = location.Y;
                p.Dead = false;

                if (e.ResetCoins)
                {
                    p.GoldCoins = default(int);
                    p.BlueCoins = default(int);
                }

                new RespawnEvent(p, location.X, location.Y, e.ResetCoins)
                    .RaiseIn(this.BotBits);
            }
        }
    }
}