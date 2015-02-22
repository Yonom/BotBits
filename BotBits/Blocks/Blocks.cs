﻿using System;
using BotBits.Events;
using BotBits.SendMessages;

namespace BotBits
{
    public sealed class Blocks : EventListenerPackage<Blocks>
    {
        private BlocksWorld _blocksWorld;
        private ReadOnlyBlocksWorld _readOnlyBlocksWorld;

        private BlocksWorld World
        {
            get { return this._blocksWorld; }
            set
            {
                this._blocksWorld = value;
                this._readOnlyBlocksWorld = new ReadOnlyBlocksWorld(_blocksWorld);
            }
        }

        public int Height
        {
            get { return this._blocksWorld.Height; }
        }

        public int Width
        {
            get { return this._blocksWorld.Width; }
        }

        public IBlockLayer<BlockData<ForegroundBlock>> Foreground
        {
            get { return this._readOnlyBlocksWorld.Foreground; }
        }

        public IBlockLayer<BlockData<BackgroundBlock>> Background
        {
            get { return this._readOnlyBlocksWorld.Background; }
        }


        [Obsolete("Invalid to use \"new\" on this class. Use the static .Of(botBits) method instead.", true)]
        public Blocks()
        {
            this.World = new BlocksWorld(0, 0);
        }

        public void Place(int x, int y, BackgroundBlock block)
        {
            new PlaceSendMessage(Layer.Background, x, y, (int)block.Id)
                .SendIn(this.BotBits);
        }

        public void Place(int x, int y, ForegroundBlock block)
        {
            new PlaceSendMessage(Layer.Foreground, x, y, (int)block.Id, block.GetArgs())
                .SendIn(this.BotBits);
        }

        [EventListener(EventPriority.High)]
        private void OnInit(InitEvent e)
        {
            this.World = WorldUtils.GetWorld(e.PlayerIOMessage, e.RoomWidth, e.RoomHeight);
            new WorldResizeEvent(e.RoomWidth, e.RoomHeight)
                .RaiseIn(this.BotBits);
        }

        [EventListener(EventPriority.High)]
        private void OnClear(ClearEvent e)
        {
            this.World = WorldUtils.GetClearedWorld(e.RoomWidth, e.RoomHeight, e.BorderBlock);
            new WorldResizeEvent(e.RoomWidth, e.RoomHeight)
                .RaiseIn(this.BotBits);
        }

        [EventListener(EventPriority.High)]
        private void OnLoadLevel(LoadLevelEvent e)
        {
            this.World = WorldUtils.GetWorld(e.PlayerIOMessage, this.Width, this.Height, 0);
        }

        [EventListener(EventPriority.High)]
        private void OnBlockPlace(BlockPlaceEvent e)
        {
            if (this.Height <= e.Y || this.Width <= e.X) return;

            switch (e.Layer)
            {
                case Layer.Foreground:
                    this.RaiseBlock(e.X, e.Y, (Foreground)e.Id, e.Player);
                    break;

                case Layer.Background:
                    this.RaiseBackground(e.X, e.Y, new BackgroundBlock((Background)e.Id), e.Player);
                    break;
            }
        }

        [EventListener(EventPriority.High)]
        private void OnPortal(PortalPlaceEvent e)
        {
            this.RaisePortalBlock(e.X, e.Y, (Foreground)e.Id, e.PortalId, e.PortalTarget, e.PortalRotation, e.Player);
        }

        [EventListener(EventPriority.High)]
        private void OnCoinDoorPlace(CoinDoorPlaceEvent e)
        {
            this.RaiseNumberBlock(e.X, e.Y, (Foreground)e.Id, e.CoinsToOpen, e.Player);
        }

        [EventListener(EventPriority.High)]
        private void OnSoundPlace(SoundPlaceEvent e)
        {
            this.RaiseNumberBlock(e.X, e.Y, (Foreground)e.Id, e.SoundId, e.Player);
        }

        [EventListener(EventPriority.High)]
        private void OnRotatablePlace(RotatablePlaceEvent e)
        {
            this.RaiseNumberBlock(e.X, e.Y, (Foreground)e.Id, e.Rotation, e.Player);
        }

        [EventListener(EventPriority.High)]
        private void OnWorldPortalPlace(WorldPortalPlaceEvent e)
        {
            this.RaiseStringBlock(e.X, e.Y, (Foreground)e.Id, e.WorldPortalTarget, e.Player);
        }

        [EventListener(EventPriority.High)]
        private void OnLabelPlace(LabelPlaceEvent e)
        {
            this.RaiseLabelBlock(e.X, e.Y, (Foreground)e.Id, e.Text, e.TextColor, e.Player);
        }

        [EventListener(EventPriority.High)]
        private void OnSignPlace(SignPlaceEvent e)
        {
            this.RaiseStringBlock(e.X, e.Y, (Foreground)e.Id, e.Text, e.Player);
        }

        private void RaiseBlock(int x, int y, Foreground block, Player player)
        {
            this.RaiseForeground(x, y, new ForegroundBlock(block), player);
        }

        private void RaiseNumberBlock(int x, int y, Foreground block, uint args, Player player)
        {
            this.RaiseForeground(x, y, new ForegroundBlock(block, args), player);
        }

        private void RaiseStringBlock(int x, int y, Foreground block, string text, Player player)
        {
            this.RaiseForeground(x, y, new ForegroundBlock(block, text), player);
        }

        private void RaiseLabelBlock(int x, int y, Foreground block, string text, string textColor, Player player)
        {
            this.RaiseForeground(x, y, new ForegroundBlock(block, text, textColor), player);
        }

        private void RaisePortalBlock(int x, int y, Foreground block, 
            uint portalId, uint portalTarget, PortalRotation portalRotation, Player player)
        {
            this.RaiseForeground(x, y, new ForegroundBlock(block, portalId, portalTarget, portalRotation), player);
        }

        private void RaiseForeground(int x, int y, ForegroundBlock newBlock, Player player)
        {
            var oldData = this.World.Foreground[x, y];
            var newData = new BlockData<ForegroundBlock>(player, newBlock);
            this.World.Foreground[x, y] = newData;

            new ForegroundPlaceEvent(x, y, oldData, newData)
                .RaiseIn(this.BotBits);
        }

        private void RaiseBackground(int x, int y, BackgroundBlock newBlock, Player player)
        {
            var oldData = this.World.Background[x, y];
            var newData = new BlockData<BackgroundBlock>(player, newBlock);
            this.World.Background[x, y] = newData;

            new BackgroundPlaceEvent(x, y, oldData, newData)
                .RaiseIn(this.BotBits);
        }
    }
}