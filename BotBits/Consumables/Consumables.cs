using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using BotBits.Events;
using BotBits.SendMessages;

namespace BotBits
{
    public sealed class Consumables : EventListenerPackage<Consumables>
    {
        private readonly Dictionary<Potion, int> _potionCounts = new Dictionary<Potion, int>();

        public bool AllowPotions { get; private set; }

        public Potion[] DisabledPotions { get; private set; }

        [Obsolete("Invalid to use \"new\" on this class. Use the static .Of(botBits) method instead.", true)]
        public Consumables()
        {
            this.DisabledPotions = new Potion[0];
        }

        [Pure]
        public int GetCount(Potion potion)
        {
            lock (this._potionCounts)
            {
                int count;
                if (!this._potionCounts.TryGetValue(potion, out count))
                    return 0;

                return count;
            }
        }

        private void SetPotion(Potion potion, int value)
        {
            lock (this._potionCounts)
            {
                this._potionCounts[potion] = value;
                
                new PotionCountEvent(potion, value)
                    .RaiseIn(this.BotBits);
            }
        }

        public void UsePotion(Potion potion)
        {
            if (!this.AllowPotions)
                throw new InvalidOperationException("Potions have been disabled in this world!");
            if (this.DisabledPotions.Contains(potion))
                throw new InvalidOperationException("That potion has been disabled in this world!");
            if (this.GetCount(potion) == 0)
                throw new InvalidOperationException("Bot does not own any potions of that type!");

            new PotionSendMessage(potion)
                .SendIn(this.BotBits);
        }

        [EventListener(EventPriority.High)]
        private void OnInit(InitEvent e)
        {
            this.AllowPotions = e.AllowPotions;
            this.ParsePotions(e);
        }

        [EventListener(EventPriority.High)]
        private void OnPotionCount(PotionsCountEvent e)
        {
            this.ParsePotions(e);
        }

        private void ParsePotions<T>(ReceiveEvent<T> e) where T : ReceiveEvent<T>
        {
            uint startNum = 0;
            for (int i = Convert.ToInt32(e.PlayerIOMessage.Count - 1u); i >= 0; i--)
            {
                if (e.PlayerIOMessage[Convert.ToUInt32(i)] as string != null &&
                    e.PlayerIOMessage.GetString(Convert.ToUInt32(i)) == "pe")
                {
                    startNum = Convert.ToUInt32(i - 1);
                }
            }

            uint pointer = startNum;
            while (e.PlayerIOMessage[pointer] as string == null || e.PlayerIOMessage.GetString(pointer) != "ps")
            {
                this.SetPotion(
                    ((Potion)e.PlayerIOMessage.GetInteger(pointer - 1)),
                    e.PlayerIOMessage.GetInteger(pointer));
                pointer -= 2;
            }
        }

        [EventListener(EventPriority.High)]
        private void OnAllowPotions(AllowPotionsEvent e)
        {
            this.AllowPotions = e.Allowed;
            this.DisabledPotions = e.DisabledPotions;
        }
    }
}