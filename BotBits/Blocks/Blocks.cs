using System;
using BotBits.Events;
using BotBits.SendMessages;

namespace BotBits
{
    public sealed class Blocks : EventListenerPackage<Blocks>, IWorld
    {
        private ReadOnlyWorld _readOnlyWorld;
        private World _world;

        private World World
        {
            get { return this._world; }
            set
            {
                this._world = value;
                this._readOnlyWorld = new ReadOnlyWorld(value);
            }
        }

        public int Height
        {
            get { return this._readOnlyWorld.Height; }
        }

        public int Width
        {
            get { return this._readOnlyWorld.Width; }
        }

        public IBlockLayer<ForegroundBlock> Foreground
        {
            get { return this._readOnlyWorld.Foreground; }
        }

        public IBlockLayer<BackgroundBlock> Background
        {
            get { return this._readOnlyWorld.Background; }
        }


        [Obsolete("Invalid to use \"new\" on this class. Use the static .Of(botBits) method instead.", true)]
        public Blocks()
        {
            this.World = new World(0, 0);
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
            this.World = WorldUtils.GetWorld(e.PlayerIOMessage, e.RoomWidth, e.RoomHeight);
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
            this.RaisePortalBlock(e.X, e.Y, (Foreground)e.Id, e.PortalId, e.PortalTarget, e.PortalRotation);
        }

        [EventListener(EventPriority.High)]
        private void OnCoinDoorPlace(CoinDoorPlaceEvent e)
        {
            this.RaiseNumberBlock(e.X, e.Y, (Foreground)e.Id, e.CoinsToOpen);
        }

        [EventListener(EventPriority.High)]
        private void OnSoundPlace(SoundPlaceEvent e)
        {
            this.RaiseNumberBlock(e.X, e.Y, (Foreground)e.Id, e.SoundId);
        }

        [EventListener(EventPriority.High)]
        private void OnRotatablePlace(RotatablePlaceEvent e)
        {
            this.RaiseNumberBlock(e.X, e.Y, (Foreground)e.Id, e.Rotation);
        }

        [EventListener(EventPriority.High)]
        private void OnWorldPortalPlace(WorldPortalPlaceEvent e)
        {
            this.RaiseStringBlock(e.X, e.Y, (Foreground)e.Id, e.WorldPortalTarget);
        }

        [EventListener(EventPriority.High)]
        private void OnLabelPlace(LabelPlaceEvent e)
        {
            this.RaiseStringBlock(e.X, e.Y, (Foreground)e.Id, e.Text);
        }

        [EventListener(EventPriority.High)]
        private void OnSignPlace(SignPlaceEvent e)
        {
            this.RaiseStringBlock(e.X, e.Y, (Foreground)e.Id, e.Text);
        }

        private void RaiseBlock(int x, int y, Foreground block, Player player)
        {
            this.RaiseForeground(x, y, new ForegroundBlock(block), player);
        }

        private void RaiseNumberBlock(int x, int y, Foreground block, uint args)
        {
            this.RaiseForeground(x, y, new ForegroundBlock(block, args));
        }

        private void RaiseStringBlock(int x, int y, Foreground block, string args)
        {
            this.RaiseForeground(x, y, new ForegroundBlock(block, args));
        }

        private void RaisePortalBlock(int x, int y,
            Foreground block, uint portalId, uint portalTarget, PortalRotation portalRotation)
        {
            this.RaiseForeground(x, y, new ForegroundBlock(block, portalId, portalTarget, portalRotation));
        }

        private void RaiseForeground(int x, int y, ForegroundBlock newBlock, Player player = null)
        {
            if (player == null) player = Player.Nobody;

            var oldBlock = this.World.Foreground[x, y];
            this.World.Foreground[x, y] = newBlock;
            new ForegroundPlaceEvent(x, y, oldBlock, newBlock, player)
                .RaiseIn(this.BotBits);
        }

        private void RaiseBackground(int x, int y, BackgroundBlock newBlock, Player player)
        {
            BackgroundBlock oldBlock = this.World.Background[x, y];
            this.World.Background[x, y] = newBlock;
            new BackgroundPlaceEvent(x, y, oldBlock, newBlock, player)
                .RaiseIn(this.BotBits);
        }
    }
}