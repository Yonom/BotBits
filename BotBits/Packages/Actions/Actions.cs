using System;
using BotBits.Events;
using BotBits.SendMessages;

namespace BotBits
{
    public sealed class Actions : EventListenerPackage<Actions>
    {
        private AccessRight _accessRight;
        private bool _canEdit;

        [Obsolete("Invalid to use \"new\" on this class. Use the static .Of(BotBits) method instead.", true)]
        public Actions()
        {
        }

        public bool Liked { get; private set; }
        public bool Favorited { get; private set; }
        public bool CompletedLevel { get; private set; }
        public bool Banned { get; private set; }

        public bool CanEdit
        {
            get { return this._canEdit; }
            private set
            {
                if (this.CanEdit != value)
                {
                    this._canEdit = value;
                    new EditRightChangedEvent(this._canEdit)
                        .RaiseIn(this.BotBits);
                }
            }
        }

        public AccessRight AccessRight
        {
            get { return this._accessRight; }
            private set
            {
                if (this.AccessRight != value)
                {
                    this._accessRight = value;
                    new AccessRightChangedEvent(this._accessRight)
                        .RaiseIn(this.BotBits);
                }
            }
        }

        [EventListener]
        private void On(InitEvent e)
        {
            this.Liked = e.Liked;
            this.Favorited = e.Favorited;
            this.CanEdit = e.CanEdit;
        }

        [EventListener(EventPriority.Low)]
        private void OnLow(InitEvent e)
        {
            if (e.IsOwner)
            {
                this.AccessRight = AccessRight.Owner;
            }
            else if (e.CanChangeWorldOptions)
            {
                this.AccessRight = AccessRight.WorldOptions;
            }
        }

        [EventListener]
        private void On(AccessEvent e)
        {
            this.CanEdit = true;
        }

        [EventListener]
        private void On(LoseAccessEvent e)
        {
            this.CanEdit = false;
        }

        [EventListener]
        private void On(LikedEvent e)
        {
            this.Liked = true;
        }

        [EventListener]
        private void On(UnlikedEvent e)
        {
            this.Liked = false;
        }

        [EventListener]
        private void On(FavoritedEvent e)
        {
            this.Favorited = true;
        }

        [EventListener]
        private void On(UnfavoritedEvent e)
        {
            this.Favorited = false;
        }

        [EventListener]
        private void On(CompletedLevelEvent e)
        {
            this.CompletedLevel = true;
        }

        [EventListener]
        private void On(BannedEvent e)
        {
            this.Banned = true;
        }

        [EventListener(EventPriority.Low)]
        private void On(WorldReleasedEvent e)
        {
            this.AccessRight = this.AccessRight == AccessRight.Owner ? AccessRight.Owner : AccessRight.None;
        }

        public void Access(string roomKey)
        {
            new AccessSendMessage(roomKey)
                .SendIn(this.BotBits);
        }

        public void RequestServerTime()
        {
            this.RequestServerTime(0);
        }

        public void RequestServerTime(double data)
        {
            new TimeSendMessage(data)
                .SendIn(this.BotBits);
        }

        public void ChangeBadge(Badge badge)
        {
            new BadgeChangeSendMessage(badge)
                .SendIn(this.BotBits);
        }

        public void ChangeSmiley(Smiley smiley)
        {
            if (this.HasSmiley(smiley)) // Server kicks people if they do not own a smiley
                new SmileySendMessage(smiley)
                    .SendIn(this.BotBits);
        }

        public void ChangeAura(AuraShape auraShape, AuraColor auraColor)
        {
            if (this.HasAura(auraShape, auraColor)) // Server kicks people if they do not own an aura
                new AuraSendMessage(auraShape, auraColor)
                    .SendIn(this.BotBits);
        }

        private bool HasSmiley(Smiley smiley)
        {
            return ConnectionManager.Of(this.BotBits).PlayerData.HasSmiley(smiley);
        }

        private bool HasAura(AuraShape auraShape, AuraColor auraColor)
        {
            return ConnectionManager.Of(this.BotBits).PlayerData.HasAuraShape(auraShape) &&
                   ConnectionManager.Of(this.BotBits).PlayerData.HasAuraColor(auraColor);
        }

        public void Move(
            int x, int y,
            double speedX, double speedY,
            double modifierX, double modifierY,
            double horizontal, double vertical,
            bool spaceDown, bool spaceJustDown,
            int tickId)
        {
            new MoveSendMessage(x, y, speedX, speedY, modifierX, modifierY, horizontal, vertical, spaceDown,
                spaceJustDown, tickId)
                .SendIn(this.BotBits);
        }

        public void GetCrown(int x, int y)
        {
            new CrownSendMessage(x, y)
                .SendIn(this.BotBits);
        }

        public void GetCoin(int coins, int blueCoins, int x, int y)
        {
            new CoinSendMessage(coins, blueCoins, x, y)
                .SendIn(this.BotBits);
        }

        public void PressSwitch(SwitchType switchType, int switchId, bool enabled, int x, int y)
        {
            new SwitchPressSendMessage(switchType, switchId, enabled, x, y)
                .SendIn(this.BotBits);
        }

        public void TouchPlayer(Player player, Effect effect)
        {
            new TouchUserSendMessage(player.UserId, effect)
                .SendIn(this.BotBits);
        }

        public void TouchPlayer(int userId, Effect effect)
        {
            new TouchUserSendMessage(userId, effect)
                .SendIn(this.BotBits);
        }

        public void PressKey(Key key, int x, int y)
        {
            new KeyPressSendMessage(key, x, y)
                .SendIn(this.BotBits);
        }

        public void Reset(int x, int y)
        {
            new ResetSendMessage(x, y)
                .SendIn(this.BotBits);
        }

        public void TouchCake(int x, int y)
        {
            new TouchCakeSendMessage(x, y)
                .SendIn(this.BotBits);
        }

        public void TouchDiamond(int x, int y)
        {
            new TouchDiamondSendMessage(x, y)
                .SendIn(this.BotBits);
        }

        public void TouchHologram(int x, int y)
        {
            new TouchHologramSendMessage(x, y)
                .SendIn(this.BotBits);
        }

        public void TouchCheckpoint(int x, int y)
        {
            new CheckpointSendMessage(x, y)
                .SendIn(this.BotBits);
        }

        public void ApplyEffect(Effect effect, int x, int y)
        {
            new EffectSendMessage(effect, x, y)
                .SendIn(this.BotBits);
        }

        public void EnterTeam(Team team, int x, int y)
        {
            new TeamSendMessage(team, x, y)
                .SendIn(this.BotBits);
        }

        public void CompleteLevel(int x, int y)
        {
            new CompleteLevelSendMessage(x, y)
                .SendIn(this.BotBits);
        }

        public void Die()
        {
            new DeathSendMessage()
                .SendIn(this.BotBits);
        }

        public void AutoSay(AutoText text)
        {
            new AutoTextSendMessage(text)
                .SendIn(this.BotBits);
        }

        public void Like()
        {
            new LikeSendMessage()
                .SendIn(this.BotBits);
        }

        public void Unlike()
        {
            new UnlikeSendMessage()
                .SendIn(this.BotBits);
        }

        public void Favorite()
        {
            new FavoriteSendMessage()
                .SendIn(this.BotBits);
        }

        public void Unfavorite()
        {
            new UnfavoriteSendMessage()
                .SendIn(this.BotBits);
        }

        public void GodMode(bool enabled)
        {
            new GodModeSendMessage(enabled)
                .SendIn(this.BotBits);
        }

        public void ToggleAdminMode()
        {
            new AdminModeSendMessage()
                .SendIn(this.BotBits);
        }

        public void ToggleModMode()
        {
            new ModModeSendMessage()
                .SendIn(this.BotBits);
        }
    }
}