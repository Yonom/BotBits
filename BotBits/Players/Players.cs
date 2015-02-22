using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using BotBits.Events;

namespace BotBits
{
    public sealed class Players : EventListenerPackage<Players>, IEnumerable<Player>
    {
        private readonly ConcurrentDictionary<int, Player> _players = new ConcurrentDictionary<int, Player>();
        public Player OwnPlayer { get; private set; }
        [CanBeNull]
        public Player CrownPlayer { get; private set; }

        public int Count
        {
            get { return this._players.Count; }
        }

        [CanBeNull]
        public Player this[int userId]
        {
            get
            {
                if (userId == Player.Nobody.UserId)
                    return Player.Nobody;

                Player player;
                if (this._players.TryGetValue(userId, out player))
                    return player;
                return null;
            }
        }

        [Obsolete("Invalid to use \"new\" on this class. Use the static .Of(botBits) method instead.", true)]
        public Players()
        {
        }

        public IEnumerator<Player> GetEnumerator()
        {
            return this.GetPlayers().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        [Pure]
        public bool Contains(int userId)
        {
            return this._players.ContainsKey(userId);
        }

        [Pure]
        public List<Player> GetPlayers()
        {
            return this._players.Values.Where(p => p.Connected).ToList();
        }

        internal Player GetOrAddPlayer(int userId)
        {
            if (userId == Player.Nobody.UserId)
                return Player.Nobody;

            return this._players.GetOrAdd(userId, i => new Player(this, i));
        }

        [EventListener(EventPriority.High)]
        private void OnInit(InitEvent e)
        {
            this.OwnPlayer = e.Player;
            this.OwnPlayer.Connected = true;
            this.OwnPlayer.Username = e.Username;
            this.OwnPlayer.X = e.SpawnX;
            this.OwnPlayer.Y = e.SpawnY;
            this.OwnPlayer.SpawnX = e.SpawnX;
            this.OwnPlayer.SpawnY = e.SpawnY;
        }

        [EventListener(EventPriority.High)]
        private void OnAdd(JoinEvent e)
        {
            Player p = e.Player;
            p.Connected = true;
            p.Username = e.Username;
            p.Smiley = e.Smiley;
            p.HasChat = e.HasChat;
            p.GodMode = e.God;
            p.GuardianMode = e.Guardian;
            p.ModMode = e.Mod;
            p.Friend = e.Friend;
            p.Coins = e.Coins;
            p.BlueCoins = e.BlueCoins;
            p.X = e.X;
            p.Y = e.Y;
            p.SpawnX = e.X;
            p.SpawnY = e.Y;
            p.ClubMember = e.ClubMember;
            p.MagicClass = e.MagicClass;
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
            if (this._players.TryRemove(e.Player.UserId, out leftPlayer))
            {
                leftPlayer.Connected = false;
            }
        }

        [EventListener(EventPriority.High)]
        private void OnCoin(CoinEvent e)
        {
            Player p = e.Player;
            p.Coins = e.Coins;
            p.BlueCoins = e.BlueCoins;
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
            p.Coins = e.Coins;
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

            if (!p.ModMode && !p.GuardianMode)
            {
                new FlyEvent(p, p.Flying)
                    .RaiseIn(this.BotBits);
            }
        }

        [EventListener(EventPriority.High)]
        private void OnGuardianMode(GuardianModeEvent e)
        {
            Player p = e.Player;
            p.GuardianMode = e.Guardian; 
            
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

            if (!p.GodMode && !p.GuardianMode)
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
        private void OnPotion(PotionEvent e)
        {
            Player p = e.Player;

            if (e.Enabled)
            {
                p.AddPotion(e.Potion);
            }
            else
            {
                p.RemovePotion(e.Potion);
            }
        }

        [EventListener(EventPriority.High)]
        private void OnLevelUp(LevelUpEvent e)
        {
            Player p = e.Player;
            p.MagicClass = e.NewClass;
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
        private void OnTeleportUser(TeleportUserEvent e)
        {
            Player p = e.Player;
            p.X = e.X;
            p.Y = e.Y;
            p.Dead = false;

            var point = new Point(p.X, p.Y);
            new TeleportEvent(p, point)
                .RaiseIn(this.BotBits);
        }

        [EventListener(EventPriority.High)]
        private void OnTeleportEveryone(TeleportEveryoneEvent e)
        {
            foreach (var tele in e.Coordinates)
            {
                Player p = this.GetOrAddPlayer(tele.Key);
                Point location = tele.Value;

                p.X = location.X;
                p.Y = location.Y;
                p.SpawnX = location.X;
                p.SpawnY = location.Y;

                p.Dead = false;

                if (e.ResetCoins)
                {
                    p.Coins = default(int);
                }

                var point = new Point(p.X, p.Y);
                new TeleportEvent(p, point)
                    .RaiseIn(this.BotBits);
            }
        }
    }
}