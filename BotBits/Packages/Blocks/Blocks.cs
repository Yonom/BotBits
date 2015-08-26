using System;
using System.Collections;
using System.Collections.Generic;
using BotBits.Events;
using BotBits.SendMessages;

namespace BotBits
{
    public sealed class Blocks : EventListenerPackage<Blocks>,  IBlockAreaEnumerable,
        IWorld<BlockData<ForegroundBlock>, BlockData<BackgroundBlock>>
    {
        private BlockDataWorld _blockDataWorld;
        private ReadOnlyBlocksWorld _readOnlyBlocksWorld;

        private BlockDataWorld World
        {
            get { return this._blockDataWorld; }
            set
            {
                this._blockDataWorld = value;
                this._readOnlyBlocksWorld = new ReadOnlyBlocksWorld(this._blockDataWorld);
            }
        }

        public BlocksItem At(Point point)
        {
            return this.At(point.X, point.Y);
        }

        public BlocksItem At(int x, int y)
        {
            return new BlocksItem(this, x, y);
        }

        public int Height
        {
            get { return this._blockDataWorld.Height; }
        }

        public int Width
        {
            get { return this._blockDataWorld.Width; }
        }

        public IBlockLayer<BlockData<ForegroundBlock>> Foreground
        {
            get { return this._readOnlyBlocksWorld.Foreground; }
        }

        public IBlockLayer<BlockData<BackgroundBlock>> Background
        {
            get { return this._readOnlyBlocksWorld.Background; }
        }

        [Obsolete("Invalid to use \"new\" on this class. Use the static .Of(BotBits) method instead.", true)]
        public Blocks()
        {
            this.World = new BlockDataWorld(0, 0);
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

        [EventListener]
        private void OnInit(InitEvent e)
        {
            this.World = BlockUtils.GetWorld(e.PlayerIOMessage, e.WorldWidth, e.WorldHeight);
        }

        [EventListener(EventPriority.Low)]
        private void OnInitLow(InitEvent e)
        {
            new WorldResizeEvent(e.WorldWidth, e.WorldHeight)
                .RaiseIn(this.BotBits);
        }

        [EventListener(EventPriority.Low)]
        private void OnClear(ClearEvent e)
        {
            this.World = BlockUtils.GetClearedWorld(e.RoomWidth, e.RoomHeight, e.BorderBlock);
            new WorldResizeEvent(e.RoomWidth, e.RoomHeight)
                .RaiseIn(this.BotBits);
        }

        [EventListener]
        private void OnLoadLevel(LoadLevelEvent e)
        {
            this.World = BlockUtils.GetWorld(e.PlayerIOMessage, this.Width, this.Height, 0);
        }

        [EventListener(EventPriority.Low)]
        private void OnBlockPlace(BlockPlaceEvent e)
        {
            if (this.Height <= e.Y || this.Width <= e.X) return;

            switch (e.Layer)
            {
                case Layer.Foreground:
                    this.RaiseBlock(e.X, e.Y, (Foreground.Id)e.Id, e.Player);
                    break;

                case Layer.Background:
                    this.RaiseBackground(e.X, e.Y, new BackgroundBlock((Background.Id)e.Id), e.Player);
                    break;
            }
        }

        [EventListener(EventPriority.Low)]
        private void OnPortalPlace(PortalPlaceEvent e)
        {
            this.RaisePortalBlock(e.X, e.Y, (Foreground.Id)e.Id, e.PortalId, e.PortalTarget, e.PortalRotation, e.Player);
        }

        [EventListener(EventPriority.Low)]
        private void OnCoinDoorPlace(CoinDoorPlaceEvent e)
        {
            this.RaiseNumberBlock(e.X, e.Y, (Foreground.Id)e.Id, e.CoinsToOpen, e.Player);
        }

        [EventListener(EventPriority.Low)]
        private void OnSoundPlace(SoundPlaceEvent e)
        {
            this.RaiseNumberBlock(e.X, e.Y, (Foreground.Id)e.Id, e.SoundId, e.Player);
        }

        [EventListener(EventPriority.Low)]
        private void OnMorphablePlace(MorphablePlaceEvent e)
        {
            this.RaiseNumberBlock(e.X, e.Y, (Foreground.Id)e.Id, e.Rotation, e.Player);
        }

        [EventListener(EventPriority.Low)]
        private void OnWorldPortalPlace(WorldPortalPlaceEvent e)
        {
            this.RaiseStringBlock(e.X, e.Y, (Foreground.Id)e.Id, e.WorldPortalTarget, e.Player);
        }

        [EventListener(EventPriority.Low)]
        private void OnLabelPlace(LabelPlaceEvent e)
        {
            this.RaiseLabelBlock(e.X, e.Y, (Foreground.Id)e.Id, e.Text, e.TextColor, e.Player);
        }

        [EventListener(EventPriority.Low)]
        private void OnSignPlace(SignPlaceEvent e)
        {
            this.RaiseStringBlock(e.X, e.Y, (Foreground.Id)e.Id, e.Text, e.Player);
        }

        private void RaiseBlock(int x, int y, Foreground.Id block, Player player)
        {
            this.RaiseForeground(x, y, new ForegroundBlock(block), player);
        }

        private void RaiseNumberBlock(int x, int y, Foreground.Id block, uint args, Player player)
        {
            this.RaiseForeground(x, y, new ForegroundBlock(block, args), player);
        }

        private void RaiseStringBlock(int x, int y, Foreground.Id block, string text, Player player)
        {
            this.RaiseForeground(x, y, new ForegroundBlock(block, text), player);
        }

        private void RaiseLabelBlock(int x, int y, Foreground.Id block, string text, string textColor, Player player)
        {
            this.RaiseForeground(x, y, new ForegroundBlock(block, text, textColor), player);
        }

        private void RaisePortalBlock(int x, int y, Foreground.Id block, 
            uint portalId, uint portalTarget, Morph.Id portalRotation, Player player)
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

        public IEnumerator<BlocksItem> GetEnumerator()
        {
            return this.In(this.Area).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        Blocks IBlockAreaEnumerable.Blocks { get { return this; } }
        public Rectangle Area { get { return new Rectangle(0, 0, this.Width, this.Height); } }
    }
}