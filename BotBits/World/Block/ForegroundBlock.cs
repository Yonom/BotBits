using System;
using System.Diagnostics;

namespace BotBits
{
    [DebuggerDisplay("Id = {Id}")]
    public struct ForegroundBlock
    {
        private readonly object _args;
        private readonly Foreground _id;
        private readonly ForegroundType _type;

        public ForegroundBlock(Foreground id)
        {
            ForegroundType type = WorldUtils.GetForegroundType(id);
            if (WorldUtils.GetBlockArgsType(type) != BlockArgsType.None)
                throw new ArgumentException("The given block is missing required arguments.", "id");

            this._args = null;
            this._type = ForegroundType.Normal;
            this._id = id;
        }


        public ForegroundBlock(Foreground id, uint args)
        {
            ForegroundType type = WorldUtils.GetForegroundType(id);
            if (WorldUtils.GetBlockArgsType(type) != BlockArgsType.Number)
                throw new ArgumentException("Invalid arguments for the specified block.", "args");

            this._args = args;
            this._type = type;
            this._id = id;
        }

        public ForegroundBlock(Foreground id, string args)
        {
            ForegroundType type = WorldUtils.GetForegroundType(id);
            if (WorldUtils.GetBlockArgsType(type) != BlockArgsType.String)
                throw new ArgumentException("Invalid arguments for the specified block.", "args");

            this._args = args;
            this._type = type;
            this._id = id;
        }

        public ForegroundBlock(Foreground id, uint portalId, uint portalTarget, PortalRotation portalRotation)
        {
            ForegroundType type = WorldUtils.GetForegroundType(id);
            if (WorldUtils.GetBlockArgsType(type) != BlockArgsType.Portal)
                throw new ArgumentException("The given block is not a portal.", "id");

            this._args = new PortalArgs(portalId, portalTarget, portalRotation);
            this._type = ForegroundType.Portal;
            this._id = id;
        }

        public ForegroundBlock(Foreground id, int coinsToCollect)
            : this(id, (uint)coinsToCollect)
        {
        }

        public ForegroundBlock(Foreground id, int portalId, int portalTarget, PortalRotation portalRotation)
            : this(id, (uint)portalId, (uint)portalTarget, portalRotation)
        {
        }

        
        public ForegroundBlock(Foreground id, SciFiSlopeRotation rotation) 
            : this(id, (uint)rotation)
        {
        }

        public ForegroundBlock(Foreground id, SciFiStraightRotation rotation)
            : this(id, (uint)rotation)
        {
        }

        public ForegroundBlock(Foreground id, SpikeRotation rotation)
            : this(id, (uint)rotation)
        {
        }

        public ForegroundBlock(Foreground id, PianoId soundId)
            : this(id, (uint)soundId)
        {
        }

        public ForegroundBlock(Foreground id, PercussionId soundId)
            : this(id, (uint)soundId)
        {
        }

        /// <summary>
        ///     Gets the block.
        /// </summary>
        /// <value>
        ///     The block.
        /// </value>
        public Foreground Id
        {
            get { return this._id; }
        }

        /// <summary>
        ///     Gets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        public ForegroundType Type
        {
            get { return this._type; }
        }

        /// <summary>
        ///     Gets the Text. (Only on label or sign blocks)
        /// </summary>
        /// <value>
        ///     The text.
        /// </value>
        /// <exception cref="System.InvalidOperationException">This property can only be accessed on label or sign blocks.</exception>
        public string Text
        {
            get
            {
                if (this.Type != ForegroundType.Text && this.Type != ForegroundType.Sign)
                    throw new InvalidOperationException("This property can only be accessed on label or sign blocks.");

                return (string)this._args;
            }
        }

        /// <summary>
        ///     Gets the world portal target. (Only on world portal blocks)
        /// </summary>
        /// <value>
        ///     The world portal target.
        /// </value>
        /// <exception cref="System.InvalidOperationException">This property can only be accessed on WorldPortal blocks.</exception>
        public string WorldPortalTarget
        {
            get
            {
                if (this.Type != ForegroundType.WorldPortal)
                    throw new InvalidOperationException("This property can only be accessed on WorldPortal blocks.");

                return (string)this._args;
            }
        }

        /// <summary>
        ///     Gets the coins to collect. (Only on coin doors)
        /// </summary>
        /// <value>
        ///     The coins to collect.
        /// </value>
        /// <exception cref="System.InvalidOperationException">This property can only be accessed on CoinDoor blocks.</exception>
        public uint CoinsToCollect
        {
            get
            {
                if (this.Type != ForegroundType.CoinDoor)
                    throw new InvalidOperationException("This property can only be accessed on CoinDoor blocks.");

                return (uint)this._args;
            }
        }

        /// <summary>
        ///     Gets the portal identifier.  (Only on portal blocks)
        /// </summary>
        /// <value>
        ///     The portal identifier.
        /// </value>
        /// <exception cref="System.InvalidOperationException">This property can only be accessed on Portal blocks.</exception>
        public uint PortalId
        {
            get
            {
                if (this.Type != ForegroundType.Portal)
                    throw new InvalidOperationException("This property can only be accessed on Portal blocks.");

                return this.GetPortalArgs().PortalId;
            }
        }

        /// <summary>
        ///     Gets the portal target.  (Only on portal blocks)
        /// </summary>
        /// <value>
        ///     The portal target.
        /// </value>
        /// <exception cref="System.InvalidOperationException">This property can only be accessed on Portal blocks.</exception>
        public uint PortalTarget
        {
            get
            {
                if (this.Type != ForegroundType.Portal)
                    throw new InvalidOperationException("This property can only be accessed on Portal blocks.");

                return this.GetPortalArgs().PortalTarget;
            }
        }

        /// <summary>
        ///     Gets the portal rotation. (Only on portal blocks)
        /// </summary>
        /// <value>
        ///     The portal rotation.
        /// </value>
        /// <exception cref="System.InvalidOperationException">This property can only be accessed on Portal blocks.</exception>
        public PortalRotation PortalRotation
        {
            get
            {
                if (this.Type != ForegroundType.Portal)
                    throw new InvalidOperationException("This property can only be accessed on Portal blocks.");

                return this.GetPortalArgs().PortalRotation;
            }
        }

        /// <summary>
        ///     Gets the piano identifier. (Only on piano blocks)
        /// </summary>
        /// <value>
        ///     The piano identifier.
        /// </value>
        /// <exception cref="System.InvalidOperationException">This property can only be accessed on Piano blocks.</exception>
        public PianoId PianoId
        {
            get
            {
                if (this.Type != ForegroundType.Piano)
                    throw new InvalidOperationException("This property can only be accessed on Piano blocks.");

                return (PianoId)this._args;
            }
        }

        /// <summary>
        ///     Gets the percussion identifier. (Only on drum blocks)
        /// </summary>
        /// <value>
        ///     The percussion identifier.
        /// </value>
        /// <exception cref="System.InvalidOperationException">This property can only be accessed on Drum blocks.</exception>
        public PercussionId PercussionId
        {
            get
            {
                if (this.Type != ForegroundType.Drum)
                    throw new InvalidOperationException("This property can only be accessed on Drum blocks.");

                return (PercussionId)this._args;
            }
        }

        /// <summary>
        ///     Gets the spike rotation. (Only on spike blocks)
        /// </summary>
        /// <value>
        ///     The spike rotation.
        /// </value>
        /// <exception cref="System.InvalidOperationException">This property can only be accessed on Spike blocks.</exception>
        public SpikeRotation SpikeRotation
        {
            get
            {
                if (this.Type != ForegroundType.Spike)
                    throw new InvalidOperationException("This property can only be accessed on Spike blocks.");

                return (SpikeRotation)this._args;
            }
        }

        /// <summary>
        ///     Gets the scifi straight rotation. (Only on scifi straight blocks)
        /// </summary>
        /// <value>
        ///     The scifi straight rotation.
        /// </value>
        /// <exception cref="System.InvalidOperationException">This property can only be accessed on SciFiStraight blocks.</exception>
        public SciFiStraightRotation SciFiStraightRotation
        {
            get
            {
                if (this.Type != ForegroundType.SciFiStraight)
                    throw new InvalidOperationException("This property can only be accessed on SciFiStraight blocks.");

                return (SciFiStraightRotation)this._args;
            }
        }


        /// <summary>
        ///     Gets the scifi slope rotation. (Only on scifi slope blocks)
        /// </summary>
        /// <value>
        ///     The scifi slope rotation.
        /// </value>
        /// <exception cref="System.InvalidOperationException">This property can only be accessed on SciFiSlope blocks.</exception>
        public SciFiSlopeRotation SciFiSlopeRotation
        {
            get
            {
                if (this.Type != ForegroundType.SciFiSlope)
                    throw new InvalidOperationException("This property can only be accessed on SciFiSlope blocks.");

                return (SciFiSlopeRotation)this._args;
            }
        }

        private PortalArgs GetPortalArgs()
        {
            return (PortalArgs)this._args;
        }

        private class PortalArgs
        {
            public PortalArgs(uint portalId, uint portalTarget, PortalRotation portalRotation)
            {
                this.PortalId = portalId;
                this.PortalTarget = portalTarget;
                this.PortalRotation = portalRotation;
            }

            public uint PortalId { get; private set; }
            public uint PortalTarget { get; private set; }
            public PortalRotation PortalRotation { get; private set; }
        }

        public object[] GetArgs()
        {
            switch (this.Type)
            {
                case ForegroundType.Normal:
                    return new object[0];
                case ForegroundType.Portal:
                    return new object[] {(uint)this.PortalRotation, this.PortalId, this.PortalTarget};
                default:
                    return new[] { this._args };
            }
        }
    }
}