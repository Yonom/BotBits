using System;
using BotBits.Events;
using BotBits.SendMessages;

namespace BotBits
{
    public sealed class Actions : EventListenerPackage<Actions>
    {
        [Obsolete("Invalid to use \"new\" on this class. Use the static .Of(BotBits) method instead.", true)]
        public Actions()
        {
        }

        public bool Liked { get; private set; }
        public bool Favorited { get; private set; }
        public bool CompletedLevel { get; private set; }

        [EventListener]
        private void On(InitEvent e)
        {
            this.Liked = e.Liked;
            this.Favorited = e.Favorited;
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

        public void ChangeSmiley(Smiley newSmiley)
        {
            if (this.HasSmiley(newSmiley)) // Server kicks people if they do not own a smiley
                new SmileySendMessage(newSmiley)
                    .SendIn(this.BotBits);
        }

        public void ChangeAura(Aura newAura)
        {
            if (this.HasAura(newAura)) // Server kicks people if they do not own an aura
                new AuraSendMessage(newAura)
                    .SendIn(this.BotBits);
        }

        private bool HasSmiley(Smiley smiley)
        {
            return ConnectionManager.Of(this.BotBits).PlayerData.HasSmiley(smiley);
        }

        private bool HasAura(Aura aura)
        {
            return ConnectionManager.Of(this.BotBits).PlayerData.HasAura(aura);
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
            new GetCrownSendMessage(x, y)
                .SendIn(this.BotBits);
        }

        public void GetCoin(int coins, int blueCoins, uint x, uint y)
        {
            new CoinSendMessage(coins, blueCoins, x, y)
                .SendIn(this.BotBits);
        }

        public void PressPurpleSwitch(int switchId, int enabled)
        {
            new PurpleSwitchSendMessage(switchId, enabled)
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

        public void ApplyEffect(Effect effect, bool activate, int x, int y)
        {
            new EffectSendMessage(effect, activate, x, y)
                .SendIn(this.BotBits);
        }

        public void ApplyTimedEffect(Effect effect, TimeSpan duration, int x, int y)
        {
            new TimedEffectSendMessage(effect, duration, x, y)
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

        public void PressKey(Key key, int x, int y)
        {
            switch (key)
            {
                case Key.Blue:
                    new BlueKeySendMessage(x, y)
                        .SendIn(this.BotBits);
                    break;

                case Key.Green:
                    new GreenKeySendMessage(x, y)
                        .SendIn(this.BotBits);
                    break;

                case Key.Red:
                    new RedKeySendMessage(x, y)
                        .SendIn(this.BotBits);
                    break;

                case Key.Cyan:
                    new CyanKeySendMessage(x, y)
                        .SendIn(this.BotBits);
                    break;

                case Key.Magenta:
                    new MagentaKeySendMessage(x, y)
                        .SendIn(this.BotBits);
                    break;

                case Key.Yellow:
                    new YellowKeySendMessage(x, y)
                        .SendIn(this.BotBits);
                    break;

                default:
                    throw new NotSupportedException("The given key could not be sent.");
            }
        }
    }
}