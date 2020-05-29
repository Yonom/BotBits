using System;
using System.Collections.Generic;
using System.Linq;
using BotBits.Events;
using BotBits.SendMessages;
using JetBrains.Annotations;

namespace BotBits
{
    public sealed class Room : EventListenerPackage<Room>
    {
        private readonly HashSet<Key> _enabledKeys = new HashSet<Key>();
        private readonly HashSet<int> _switches = new HashSet<int>();


        [Obsolete("Invalid to use \"new\" on this class. Use the static .Of(BotBits) method instead.", true)]
        public Room()
        {
        }

        public string WorldName { get; private set; }
        public string Owner { get; private set; }
        public int Plays { get; private set; }
        public int Favorites { get; private set; }
        public int Likes { get; private set; }
        public double GravityMultiplier { get; private set; }
        public uint BackgroundColor { get; private set; }
        public AccessGroup AccessGroup { get; private set; }
        public bool InitComplete { get; private set; }
        public bool JoinComplete { get; private set; }
        public bool AllowSpectating { get; private set; }
        public bool HideLobby { get; private set; }
        public string Description { get; private set; }
        public int CurseLimit { get; private set; }
        public int ZombieLimit { get; private set; }
        public string CrewName { get; private set; }
        public string CrewId { get; private set; }
        public bool Campaign { get; private set; }
        public WorldStatus WorldStatus { get; private set; }
        public bool MinimapEnabled { get; private set; }
        public bool LobbyPreviewEnabled { get; private set; }
        public string OwnerConnectUserId { get; private set; }

        [Pure]
        public bool IsKeyPressed(Key key)
        {
            return this._enabledKeys.Contains(key);
        }

        [Pure]
        public bool IsSwitchPressed(int id)
        {
            lock (this._switches)
            {
                return this._switches.Contains(id);
            }
        }

        [Pure]
        public int[] GetSwitches()
        {
            lock (this._switches)
            {
                return this._switches.ToArray();
            }
        }

        internal void AddSwitch(int id)
        {
            lock (this._switches)
            {
                this._switches.Add(id);
            }
        }

        internal void RemoveSwitch(int id)
        {
            lock (this._switches)
            {
                this._switches.Remove(id);
            }
        }

        internal void ResetSwitches()
        {
            lock (this._switches)
            {
                this._switches.Clear();
            }
        }

        public void SetEditKey(string newKey)
        {
            new SetEditKeySendMessage(newKey)
                .SendIn(this.BotBits);
        }

        public void Clear()
        {
            new ClearSendMessage()
                .SendIn(this.BotBits);
        }

        public void Save()
        {
            new SaveSendMessage()
                .SendIn(this.BotBits);
        }

        public void SetName(string newName)
        {
            new SetNameSendMessage(newName)
                .SendIn(this.BotBits);
        }

        public void SetAccessGroup(AccessGroup accessGroup)
        {
            new SetRoomAccessGroupSendMessage(accessGroup)
                .SendIn(this.BotBits);
        }

        public void SetHideLobby(bool hidden)
        {
            new SetHideLobbySendMessage(hidden)
                .SendIn(this.BotBits);
        }

        public void SetAllowSpectating(bool allow)
        {
            new SetAllowSpectatingSendMessage(allow)
                .SendIn(this.BotBits);
        }

        public void SetMinimapEnabled(bool enabled)
        {
            new SetMinimapEnabledSendMessage(enabled)
                .SendIn(this.BotBits);
        }

        public void SetLobbyPreviewEnabled(bool enabled)
        {
            new SetLobbyPreviewEnabledSendMessage(enabled)
                .SendIn(this.BotBits);
        }

        public void SetDescription(string description)
        {
            new SetRoomDescriptionSendMessage(description)
                .SendIn(this.BotBits);
        }

        public void SetCurseLimit(int limit)
        {
            new SetCurseLimitSendMessage(limit)
                .SendIn(this.BotBits);
        }

        public void SetZombieLimit(int limit)
        {
            new SetZombieLimitSendMessage(limit)
                .SendIn(this.BotBits);
        }

        public void SetStatus(WorldStatus status)
        {
            new SetStatusSendMessage(status)
                .SendIn(this.BotBits);
        }

        public void RequestAddToCrew(string crewId)
        {
            new RequestAddToCrewSendMessage(crewId)
                .SendIn(this.BotBits);
        }

        public void AddToCrew()
        {
            new AddToCrewSendMessage()
                .SendIn(this.BotBits);
        }

        public void RejectAddToCrew()
        {
            new RejectAddToCrewSendMessage()
                .SendIn(this.BotBits);
        }

        public void KillRoom()
        {
            new KillRoomSendMessage()
                .SendIn(this.BotBits);
        }

        [EventListener]
        private void On(HideKeyEvent e)
        {
            this._enabledKeys.Add(e.Key);
        }

        [EventListener]
        private void On(ShowKeyEvent e)
        {
            this._enabledKeys.Remove(e.Key);
        }

        [EventListener]
        private void On(WorldReleasedEvent e)
        {
            this.WorldStatus = WorldStatus.Released;
        }

        [EventListener]
        private void On(InitEvent e)
        {
            this.Owner = e.Owner;
            this.WorldName = e.WorldName;
            this.Plays = e.Plays;
            this.Campaign = e.Campaign;
            this.GravityMultiplier = e.GravityMultiplier;
            this.Favorites = e.Favorites;
            this.Likes = e.Likes;
            this.BackgroundColor = e.BackgroundColor;
            this.AccessGroup = e.AccessGroup;
            this.HideLobby = e.HideLobby;
            this.AllowSpectating = e.AllowSpectating;
            this.Description = e.RoomDescription;
            this.ZombieLimit = e.ZombieLimit;
            this.CurseLimit = e.CurseLimit;
            this.CrewId = e.CrewId;
            this.CrewName = e.CrewId;
            this.WorldStatus = e.WorldStatus;
            this.MinimapEnabled = e.MinimapEnabled;
            this.LobbyPreviewEnabled = e.LobbyPreviewEnabled;
            this.OwnerConnectUserId = e.OwnerConnectUserId;

            this.InitComplete = true;

            new Init2SendMessage()
                .SendIn(this.BotBits);
        }

        [EventListener(EventPriority.Low)]
        private void OnLow(InitEvent e)
        {
            foreach (var os in e.OrangeSwitches)
            {
                this.AddSwitch(os);
                new OrangeSwitchEvent(os, true)
                    .RaiseIn(this.BotBits);
            }

            new MetaChangedEvent(e.Owner, e.Plays, e.Favorites, e.Likes, e.WorldName)
                .RaiseIn(this.BotBits);
        }

        [EventListener]
        private void On(SwitchUpdateEvent e)
        {
            if (e.SwitchType != SwitchType.Orange) return;

            if (e.Enabled) this.AddSwitch(e.Id);
            else this.RemoveSwitch(e.Id);

            new OrangeSwitchEvent(e.Id, e.Enabled)
                .RaiseIn(this.BotBits);
        }

        [EventListener]
        private void On(JoinCompleteEvent e)
        {
            this.JoinComplete = true;
        }

        [EventListener]
        private void On(UpdateMetaEvent e)
        {
            this.WorldName = e.WorldName;
            this.Plays = e.Plays;
            this.Owner = e.OwnerUsername;
            this.Favorites = e.Favorites;
            this.Likes = e.Likes;

            new MetaChangedEvent(e.OwnerUsername, e.Plays, e.Favorites, e.Likes, e.WorldName)
                .RaiseIn(this.BotBits);
        }

        [EventListener]
        private void On(BackgroundColorEvent e)
        {
            this.BackgroundColor = e.BackgroundColor;
        }

        [EventListener]
        private void On(AddedToCrewEvent e)
        {
            this.CrewId = e.CrewId;
            this.CrewName = e.CrewName;
        }

        [EventListener]
        private void On(RoomAccessGroupEvent e)
        {
            this.AccessGroup = e.AccessGroup;
        }

        [EventListener]
        private void On(HideLobbyEvent e)
        {
            this.HideLobby = e.Hidden;
        }

        [EventListener]
        private void On(AllowSpectatingEvent e)
        {
            this.AllowSpectating = e.Allow;
        }

        [EventListener]
        private void On(RoomDescriptionEvent e)
        {
            this.Description = e.Description;
        }

        [EventListener]
        private void On(EffectLimitsEvent e)
        {
            this.ZombieLimit = e.ZombieLimit;
            this.CurseLimit = e.CurseLimit;
        }

        [EventListener]
        private void On(MinimapEnabledEvent e)
        {
            this.MinimapEnabled = e.Enabled;
        }

        [EventListener]
        private void On(LobbyPreviewEnabledEvent e)
        {
            this.LobbyPreviewEnabled = e.Enabled;
        }

        [EventListener]
        private void On(MultiRespawnEvent e)
        {
            if (!e.ResetLevel) return;
            this.ResetSwitches();
        }
    }
}