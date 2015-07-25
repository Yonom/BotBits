﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BotBits.Events
{
    /// <summary>
    /// Occurs when a player's purple switvch state changes
    /// </summary>
    public sealed class PurpleSwitchEvent : Event<PurpleSwitchEvent>
    {
        public Player Player { get; private set; }
        public int SwitchId { get; private set; }
        public bool Enabled { get; private set; }

        internal PurpleSwitchEvent(Player player, int switchId, bool enabled)
        {
            this.Enabled = enabled;
            this.SwitchId = switchId;
            this.Player = player;
        }
    }
}