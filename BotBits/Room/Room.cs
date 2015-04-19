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
        public string WorldName { get; private set; }
        public string Owner { get; private set; }
        public int Plays { get; private set; }
        public int CurrentWoots { get; private set; }
        public int TotalWoots { get; private set; }
        public string Token { get; private set; }
        public double GravityMultiplier { get; private set; }
        public bool TutorialRoom { get; private set; }
        public uint BackgroundColor { get; private set; }
        public bool Visible { get; private set; }
        public bool InitComplete { get; private set; }
        public bool JoinComplete { get; private set; }
        public bool AllowSpectating { get; set; }
        public bool HideLobby { get; set; }
        public string Description { get; set; }

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

        public void Access(string roomKey)
        {
            new AccessSendMessage(roomKey)
                .SendIn(this.BotBits);
        }

        public void SetEditKey(string newKey)
        {
            if (this.AccessRight < AccessRight.Owner)
                throw new InvalidOperationException("Only owners are allowed to change key.");

            new SetEditKeySendMessage(newKey)
                .SendIn(this.BotBits);
        }

        public void Clear()
        {
            if (this.AccessRight < AccessRight.Owner)
                throw new InvalidOperationException("Only owners are allowed to clear room.");

            new ClearSendMessage()
                .SendIn(this.BotBits);
        }

        public void Save()
        {
            if (this.AccessRight < AccessRight.Owner)
                throw new InvalidOperationException("Only owners are allowed to save.");

            new SaveSendMessage()
                .SendIn(this.BotBits);
        }

        public void SetName(string newName)
        {
            if (this.AccessRight < AccessRight.Owner)
                throw new InvalidOperationException("Only owners are allowed to change room name.");

            new RoomNameSendMessage(newName)
                .SendIn(this.BotBits);
        }

        public void SetRoomVisible(bool visible)
        {
            if (this.AccessRight < AccessRight.Owner)
                throw new InvalidOperationException("Only owners are allowed to change room visiblity.");

            new SetRoomVisibleSendMessage(visible)
                .SendIn(this.BotBits);
        }

        public void SetHideLobby(bool hidden)
        {
            if (this.AccessRight < AccessRight.Owner)
                throw new InvalidOperationException("Only owners are allowed to change room visibility.");

            new SetHideLobbySendMessage(hidden)
                .SendIn(this.BotBits);
        }

        public void SetAllowSpectating(bool allow)
        {
            if (this.AccessRight < AccessRight.Owner)
                throw new InvalidOperationException("Only owners are allowed to change spectator settings.");

            new SetAllowSpectatingSendMessage(allow)
                .SendIn(this.BotBits);
        }

        public void SetRoomDescription(string description)
        {
            if (this.AccessRight < AccessRight.Owner)
                throw new InvalidOperationException("Only owners are allowed to change room description.");

            new SetRoomDescriptionSendMessage(description)
                .SendIn(this.BotBits);
        }

        public void KillRoom()
        {
            new KillRoomSendMessage()
                .SendIn(this.BotBits);
        }

        [EventListener(EventPriority.High)]
        private void OnHideKey(HideKeyEvent e)
        {
            this._enabledKeys.Remove(e.Key);
        }

        [EventListener(EventPriority.High)]
        private void OnShowKey(ShowKeyEvent e)
        {
            this._enabledKeys.Add(e.Key);
        }

        [EventListener(EventPriority.High)]
        private void OnInit(InitEvent e)
        {
            this.Owner = e.Owner;
            this.WorldName = e.WorldName;
            this.Plays = e.Plays;
            this.Token = Utils.Rot13(e.EncryptedToken);
            this.TutorialRoom = e.TutorialRoom;
            this.GravityMultiplier = e.GravityMultiplier;
            this.CurrentWoots = e.CurrentWoots;
            this.TotalWoots = e.TotalWoots;
            this.BackgroundColor = e.BackgroundColor;
            this.Visible = e.Visible;
            this.HideLobby = e.HideLobby;
            this.AllowSpectating = e.AllowSpectating;
            this.Description = e.RoomDescription;

            if (e.IsOwner)
            {
                this.AccessRight = AccessRight.Owner;
            }
            else if (e.CanEdit)
            {
                this.AccessRight = AccessRight.Edit;
            }
            
            new MetaChangedEvent(e.Owner, e.Plays, e.CurrentWoots, e.TotalWoots, e.WorldName)
                .RaiseIn(this.BotBits);
            this.InitComplete = true;
        }

        [EventListener(EventPriority.High)]
        private void OnAccess(AccessEvent e)
        {
            this.AccessRight = AccessRight.Edit;
        }

        [EventListener(EventPriority.High)]
        private void OnLostAccess(LoseAccessEvent e)
        {
            this.AccessRight = AccessRight.None;
        }

        [EventListener(EventPriority.High)]
        private void OnCrown(CrownEvent e)
        {
            if (!this.JoinComplete)
            {
                this.JoinComplete = true;
                new JoinCompleteEvent()
                    .RaiseIn(this.BotBits);
            }
        }

        [EventListener(EventPriority.High)]
        private void OnUpdateMeta(UpdateMetaEvent e)
        {
            this.WorldName = e.WorldName;
            this.Plays = e.Plays;
            this.Owner = e.OwnerUsername;
            this.CurrentWoots = e.CurrentWoots;
            this.TotalWoots = e.TotalWoots;

            new MetaChangedEvent(e.OwnerUsername, e.Plays, e.CurrentWoots, e.TotalWoots, e.WorldName)
                .RaiseIn(this.BotBits);
        }

        [EventListener(EventPriority.High)]
        private void OnBackgroundColor(BackgroundColorEvent e)
        {
            this.BackgroundColor = e.BackgroundColor;
        }

        [EventListener(EventPriority.High)]
        private void OnRoomVisible(RoomVisibleEvent e)
        {
            this.Visible = e.Visible;
        }

        [EventListener(EventPriority.High)]
        private void OnHideLobby(HideLobbyEvent e)
        {
            this.HideLobby = e.Hidden;
        }

        [EventListener(EventPriority.High)]
        private void OnAllowSpectating(AllowSpectatingEvent e)
        {
            this.AllowSpectating = e.Allow;
        }

        [EventListener(EventPriority.High)]
        private void OnRoomDescription(RoomDescriptionEvent e)
        {
            this.Description = e.Description;
        }
    }
}