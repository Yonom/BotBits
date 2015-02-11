using System;
using System.Diagnostics;
using BotBits.Events;
using BotBits.SendMessages;

namespace BotBits
{
    public sealed class Actions : Package<Actions>
    {
        [Obsolete("Invalid to use \"new\" on this class. Use the static .Of(botBits) method instead.", true)]
        public Actions()
        {
        }

        public void ChangeSmiley(Smiley newSmiley)
        {
            new SmileySendMessage(newSmiley)
                .SendIn(this.BotBits);
        }

        public void MoveToLocation(int x, int y)
        {
            new MoveSendMessage(x, y, 0, 0, 0, 0, 0, 0, false)
                .SendIn(this.BotBits);
        }

        public void Move(
            int x, int y, 
            double speedX, double speedY, 
            double modifierX, double modifierY,
            double horizontal, double vertical, 
            bool spaceDown)
        {
            new MoveSendMessage(x, y, speedX, speedY, modifierX, modifierY, horizontal, vertical, spaceDown)
                .SendIn(this.BotBits);
        }

        public void GetCrown()
        {
            new GetCrownSendMessage()
                .SendIn(this.BotBits);
        }

        public void GetCoin(int coins, int blueCoins, int x, int y)
        {
            new CoinSendMessage(coins, blueCoins, x, y)
                .SendIn(this.BotBits);
        }

        public void TouchPlayer(Player player, Potion reason)
        {
            new TouchUserSendMessage(player.UserId, reason)
                .SendIn(this.BotBits);
        }

        public void TouchPlayer(int userId, Potion reason)
        {
            new TouchUserSendMessage(userId, reason)
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

        public void CompleteLevel()
        {
            new CompleteLevelSendMessage()
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

        public void WootUp()
        {
            new WootUpSendMessage()
                .SendIn(this.BotBits);
        }

        public void GodMode(bool enabled)
        {
            new GodModeSendMessage(enabled)
                .SendIn(this.BotBits);
        }

        public void ToggleGuardianMode()
        {
            new GuardianModeSendMessage()
                .SendIn(this.BotBits);
        }

        public void ToggleModMode() 
        {
            new ModModeSendMessage()
                .SendIn(this.BotBits);
        }
    }
}