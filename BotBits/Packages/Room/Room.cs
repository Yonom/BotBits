using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using BotBits.Events;
using BotBits.SendMessages;

namespace BotBits
{
    public sealed class Room : EventListenerPackage<Room>
    {
        private readonly HashSet<Key> _enabledKeys = new HashSet<Key>();
        private AccessRight _accessRight;
        private bool _canEdit;
        public string WorldName { get; private set; }
        public string Owner { get; private set; }
        public int Plays { get; private set; }
        public int Favorites { get; private set; }
        public int Likes { get; private set; }
        public string Token { get; private set; }
        public double GravityMultiplier { get; private set; }
        public uint BackgroundColor { get; private set; }
        public bool Visible { get; private set; }
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

        public bool CanEdit
        {
            get { return this._canEdit; }
            private set {             
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

        [Obsolete("Invalid to use \"new\" on this class. Use the static .Of(botBits) method instead.", true)]
        public Room()
        {
        }

        [Pure]
        public bool IsKeyPressed(Key key)
        {
            return this._enabledKeys.Contains(key);
        }

        public void SetEditKey(string newKey)
        {
            if (this.AccessRight < AccessRight.WorldOptions)
                throw new InvalidOperationException("Only owners are allowed to change key.");

            new SetEditKeySendMessage(newKey)
                .SendIn(this.BotBits);
        }

        public void Clear()
        {
            if (this.AccessRight < AccessRight.WorldOptions)
                throw new InvalidOperationException("Only owners are allowed to clear room.");

            new ClearSendMessage()
                .SendIn(this.BotBits);
        }

        public void Save()
        {
            if (this.AccessRight < AccessRight.WorldOptions)
                throw new InvalidOperationException("Only owners are allowed to save.");

            new SaveSendMessage()
                .SendIn(this.BotBits);
        }

        public void SetName(string newName)
        {
            if (this.AccessRight < AccessRight.WorldOptions)
                throw new InvalidOperationException("Only owners are allowed to change room name.");

            new RoomNameSendMessage(newName)
                .SendIn(this.BotBits);
        }

        public void SetRoomVisible(bool visible)
        {
            if (this.AccessRight < AccessRight.WorldOptions)
                throw new InvalidOperationException("Only owners are allowed to change room visiblity.");

            new SetRoomVisibleSendMessage(visible)
                .SendIn(this.BotBits);
        }

        public void SetHideLobby(bool hidden)
        {
            if (this.AccessRight < AccessRight.WorldOptions)
                throw new InvalidOperationException("Only owners are allowed to change room visibility.");

            new SetHideLobbySendMessage(hidden)
                .SendIn(this.BotBits);
        }

        public void SetAllowSpectating(bool allow)
        {
            if (this.AccessRight < AccessRight.WorldOptions)
                throw new InvalidOperationException("Only owners are allowed to change spectator settings.");

            new SetAllowSpectatingSendMessage(allow)
                .SendIn(this.BotBits);
        }

        public void SetRoomDescription(string description)
        {
            if (this.AccessRight < AccessRight.WorldOptions)
                throw new InvalidOperationException("Only owners are allowed to change room description.");

            new SetRoomDescriptionSendMessage(description)
                .SendIn(this.BotBits);
        }

        public void SetCurseLimit(int limit)
        {
            if (this.AccessRight < AccessRight.WorldOptions)
                throw new InvalidOperationException("Only owners are allowed to change curse limit.");

            new SetCurseLimitSendMessage(limit)
                .SendIn(this.BotBits);
        }

        public void SetZombieLimit(int limit)
        {
            if (this.AccessRight < AccessRight.WorldOptions)
                throw new InvalidOperationException("Only owners are allowed to change zombie limit.");

            new SetZombieLimitSendMessage(limit)
                .SendIn(this.BotBits);
        }

        public void SetStatus(WorldStatus status)
        {
            if (this.AccessRight < AccessRight.WorldOptions)
                throw new InvalidOperationException("Only owners are allowed to change world status."); // TODO update messages

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
        private void OnHideKey(HideKeyEvent e)
        {
            this._enabledKeys.Remove(e.Key);
        }

        [EventListener]
        private void OnShowKey(ShowKeyEvent e)
        {
            this._enabledKeys.Add(e.Key);
        }

        [EventListener]
        private void OnReleased(WorldReleasedEvent e)
        {
            this.WorldStatus = WorldStatus.Released;
            this.AccessRight = this.AccessRight == AccessRight.Owner ? AccessRight.Owner : AccessRight.None;
        }

        [EventListener]
        private void OnInit(InitEvent e)
        {
            this.Owner = e.Owner;
            this.WorldName = e.WorldName;
            this.Plays = e.Plays;
            this.Token = Utils.Rot13(e.EncryptedToken);
            this.Campaign = e.Campaign;
            this.GravityMultiplier = e.GravityMultiplier;
            this.Favorites = e.Favorites;
            this.Likes = e.Likes;
            this.BackgroundColor = e.BackgroundColor;
            this.Visible = e.Visible;
            this.HideLobby = e.HideLobby;
            this.AllowSpectating = e.AllowSpectating;
            this.Description = e.RoomDescription;
            this.ZombieLimit = e.ZombieLimit;
            this.CurseLimit = e.CurseLimit;
            this.CrewId = e.CrewId;
            this.CrewName = e.CrewId;
            this.WorldStatus = e.WorldStatus;
            this.CanEdit = e.CanEdit;
            this.InitComplete = true;
        }

        [EventListener(EventPriority.Low)]
        private void OnInitLow(InitEvent e)
        {
            if (e.IsOwner)
            {
                this.AccessRight = AccessRight.Owner;
            }
            else if (e.CanChangeWorldOptions)
            {
                this.AccessRight = AccessRight.WorldOptions;
            }

            new MetaChangedEvent(e.Owner, e.Plays, e.Favorites, e.Likes, e.WorldName)
                .RaiseIn(this.BotBits);
        }

        [EventListener(EventPriority.Low)]
        private void OnAccess(AccessEvent e)
        {
            this.CanEdit = true;
        }

        [EventListener(EventPriority.Low)]
        private void OnLostAccess(LoseAccessEvent e)
        {
            this.CanEdit = false;
        }

        [EventListener(EventPriority.Low)]
        private void OnCrown(CrownEvent e)
        {
            if (!this.JoinComplete)
            {
                this.JoinComplete = true;
                new JoinCompleteEvent()
                    .RaiseIn(this.BotBits);
            }
        }

        [EventListener(EventPriority.Low)]
        private void OnUpdateMeta(UpdateMetaEvent e)
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
        private void OnBackgroundColor(BackgroundColorEvent e)
        {
            this.BackgroundColor = e.BackgroundColor;
        }

        [EventListener]
        private void OnAddedToCrew(AddedToCrewEvent e)
        {
            this.CrewId = e.CrewId;
            this.CrewName = e.CrewName;
        }

        [EventListener]
        private void OnRoomVisible(RoomVisibleEvent e)
        {
            this.Visible = e.Visible;
        }

        [EventListener]
        private void OnHideLobby(HideLobbyEvent e)
        {
            this.HideLobby = e.Hidden;
        }

        [EventListener]
        private void OnAllowSpectating(AllowSpectatingEvent e)
        {
            this.AllowSpectating = e.Allow;
        }

        [EventListener]
        private void OnRoomDescription(RoomDescriptionEvent e)
        {
            this.Description = e.Description;
        }

        [EventListener]
        private void OnEffectsLimit(EffectLimitsEvent e)
        {
            this.ZombieLimit = e.ZombieLimit;
            this.CurseLimit = e.CurseLimit;
        }
    }
}