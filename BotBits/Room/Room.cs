using System;
using System.Collections.Generic;
using System.Diagnostics;
using BotBits.Annotations;
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

        public void PressKey(Key key)
        {
            switch (key)
            {
                case Key.Blue:
                    new BlueKeySendMessage()
                        .SendIn(this.BotBits);
                    break;

                case Key.Green:
                    new GreenKeySendMessage()
                        .SendIn(this.BotBits);
                    break;

                case Key.Red:
                    new RedKeySendMessage()
                        .SendIn(this.BotBits);
                    break;

                default:
                    throw new NotSupportedException("The given key could not be sent.");
            }
        }

        public void Access(string roomKey)
        {
            new AccessSendMessage(roomKey)
                .SendIn(this.BotBits);
        }

        public void ChangeKey(string newKey)
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

        public void SetAllowPotions(bool allowed)
        {
            if (this.AccessRight < AccessRight.Owner)
                throw new InvalidOperationException("Only owners are allowed to enable/disable potions.");

            new AllowPotionsSendMessage(allowed)
                .SendIn(this.BotBits);
        }

        public void SetName(string newName)
        {
            if (this.AccessRight < AccessRight.Owner)
                throw new InvalidOperationException("Only owners are allowed to change room name.");

            new RoomNameSendMessage(newName)
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
            foreach (Key k in e.Keys)
            {
                this._enabledKeys.Remove(k);
            }
        }

        [EventListener(EventPriority.High)]
        private void OnShowKey(ShowKeyEvent e)
        {
            foreach (Key k in e.Keys)
            {
                this._enabledKeys.Add(k);
            }
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
    }
}