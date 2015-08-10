using System;
using System.Diagnostics;

namespace BotBits
{
    [DebuggerDisplay("Id = {Id}")]
    public struct ForegroundBlock : IEquatable<ForegroundBlock>
    {
        public bool Equals(ForegroundBlock other)
        {
            return Equals(this._args, other._args) && this._id == other._id && this._type == other._type;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is ForegroundBlock && Equals((ForegroundBlock)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = (this._args != null ? this._args.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (int)this._id;
                hashCode = (hashCode * 397) ^ (int)this._type;
                return hashCode;
            }
        }

        public static bool operator ==(ForegroundBlock left, ForegroundBlock right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ForegroundBlock left, ForegroundBlock right)
        {
            return !left.Equals(right);
        }

        private readonly object _args;
        private readonly Foreground.Id _id;
        private readonly ForegroundType _type;

        public ForegroundBlock(Foreground.Id id)
        {
            ForegroundType type = WorldUtils.GetForegroundType(id);
            if (WorldUtils.GetBlockArgsType(type) != BlockArgsType.None)
                throw new ArgumentException("The given block is missing required arguments.", "id");

            this._args = null;
            this._type = ForegroundType.Normal;
            this._id = id;
        }


        public ForegroundBlock(Foreground.Id id, uint args)
        {
            ForegroundType type = WorldUtils.GetForegroundType(id);
            if (WorldUtils.GetBlockArgsType(type) != BlockArgsType.Number)
                throw new ArgumentException("Invalid arguments for the specified block.", "id");

            this._args = args;
            this._type = type;
            this._id = id;
        }

        public ForegroundBlock(Foreground.Id id, string text)
        {
            ForegroundType type = WorldUtils.GetForegroundType(id);
            if (WorldUtils.GetBlockArgsType(type) != BlockArgsType.String)
                throw new ArgumentException("Invalid arguments for the specified block.", "id");

            this._args = text;
            this._type = type;
            this._id = id;
        }

        public ForegroundBlock(Foreground.Id id, string text, string textColor)
        {
            ForegroundType type = WorldUtils.GetForegroundType(id);
            if (WorldUtils.GetBlockArgsType(type) != BlockArgsType.Label)
                throw new ArgumentException("Invalid arguments for the specified block.", "id");

            this._args = new LabelArgs(text, textColor);
            this._type = type;
            this._id = id;
        }

        public ForegroundBlock(Foreground.Id id, uint portalId, uint portalTarget, Morph.Id portalRotation)
        {
            ForegroundType type = WorldUtils.GetForegroundType(id);
            if (WorldUtils.GetBlockArgsType(type) != BlockArgsType.Portal)
                throw new ArgumentException("The given block is not a portal.", "id");

            this._args = new PortalArgs(portalId, portalTarget, portalRotation);
            this._type = ForegroundType.Portal;
            this._id = id;
        }

        public ForegroundBlock(Foreground.Id id, int portalId, int portalTarget, Morph.Id portalRotation)
            : this(id, (uint)portalId, (uint)portalTarget, portalRotation)
        {
        }

        public ForegroundBlock(Foreground.Id id, int goal)
            : this(id, (uint)goal)
        {
        }

        public ForegroundBlock(Foreground.Id id, bool enabled)
            : this(id, enabled ? 1 : 0)
        {
        }

        public ForegroundBlock(Foreground.Id id, Morph.Id morph)
            : this(id, (uint)morph)
        {
        }

        /// <summary>
        ///     Gets the block.
        /// </summary>
        /// <value>
        ///     The block.
        /// </value>
        public Foreground.Id Id
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
        ///     Gets the Text. (Only on label or text blocks)
        /// </summary>
        /// <value>
        ///     The text.
        /// </value>
        /// <exception cref="System.InvalidOperationException">This property can only be accessed on label or text blocks.</exception>
        public string Text
        {
            get
            {
                switch (this.Type)
                {
                    case ForegroundType.Text:
                        return (string)this._args;
                    case ForegroundType.Label:
                        return this.GetLabelArgs().Text;
                    default:
                        throw new InvalidOperationException("This property can only be accessed on label or text blocks.");
                }
            }
        }

        /// <summary>
        ///     Gets the Text. (Only on label blocks)
        /// </summary>
        /// <value>
        ///     The text.
        /// </value>
        /// <exception cref="System.InvalidOperationException">This property can only be accessed on label blocks.</exception>
        public string TextColor
        {
            get
            {
                if (this.Type != ForegroundType.Label)
                    throw new InvalidOperationException("This property can only be accessed on label blocks.");

                return this.GetLabelArgs().TextColor;
            }
        }

        /// <summary>
        ///     Gets the toggled state. (Only on toggle)
        /// </summary>
        /// <value>
        ///     The toggle state.
        /// </value>
        /// <exception cref="System.InvalidOperationException">This property can only be accessed on toggle blocks.</exception>
        public bool Enabled
        {
            get
            {
                if (this.Type != ForegroundType.Toggle && this.Type != ForegroundType.ToggleGoal)
                    throw new InvalidOperationException("This property can only be accessed on toggle blocks.");

                return (uint)this._args != 0;
            }
        }

        /// <summary>
        ///     Gets the goal. (Only on goal blocks)
        /// </summary>
        /// <value>
        ///     The coins to collect.
        /// </value>
        /// <exception cref="System.InvalidOperationException">This property can only be accessed on goal blocks.</exception>
        public uint Goal
        {
            get
            {
                if (this.Type != ForegroundType.Goal)
                    throw new InvalidOperationException("This property can only be accessed on goal blocks.");

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
        ///     Gets the world portal target.  (Only on world portal blocks)
        /// </summary>
        /// <value>
        ///     The portal target.
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
        ///     Gets the morph. (Only on morphable blocks)
        /// </summary>
        /// <value>
        ///     The morph.
        /// </value>
        /// <exception cref="System.InvalidOperationException">This property can only be accessed on morphable blocks.</exception>
        public Morph.Id Morph
        {
            get
            {
                switch (this.Type)
                {
                    case ForegroundType.Portal:
                        return this.GetPortalArgs().PortalRotation;
                    case ForegroundType.Morphable:
                    case ForegroundType.Note:
                    case ForegroundType.Team:
                        return (Morph.Id)(uint)this._args;
                    default:
                        throw new InvalidOperationException("This property can only be accessed on morphable blocks.");
                }

            }
        }

        private PortalArgs GetPortalArgs()
        {
            return (PortalArgs)this._args;
        }

        private LabelArgs GetLabelArgs()
        {
            return (LabelArgs)this._args;
        }

        private class PortalArgs : IEquatable<PortalArgs>
        {
            public bool Equals(PortalArgs other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return this.PortalId == other.PortalId && this.PortalTarget == other.PortalTarget && this.PortalRotation == other.PortalRotation;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((PortalArgs)obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    int hashCode = (int)this.PortalId;
                    hashCode = (hashCode * 397) ^ (int)this.PortalTarget;
                    hashCode = (hashCode * 397) ^ (int)this.PortalRotation;
                    return hashCode;
                }
            }

            public static bool operator ==(PortalArgs left, PortalArgs right)
            {
                return Equals(left, right);
            }

            public static bool operator !=(PortalArgs left, PortalArgs right)
            {
                return !Equals(left, right);
            }

            public PortalArgs(uint portalId, uint portalTarget, Morph.Id portalRotation)
            {
                this.PortalId = portalId;
                this.PortalTarget = portalTarget;
                this.PortalRotation = portalRotation;
            }

            public uint PortalId { get; private set; }
            public uint PortalTarget { get; private set; }
            public Morph.Id PortalRotation { get; private set; }
        }

        private class LabelArgs : IEquatable<LabelArgs>
        {
            public bool Equals(LabelArgs other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return string.Equals(this.Text, other.Text) && string.Equals(this.TextColor, other.TextColor);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((LabelArgs)obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return ((this.Text != null ? this.Text.GetHashCode() : 0) * 397) ^ (this.TextColor != null ? this.TextColor.GetHashCode() : 0);
                }
            }

            public static bool operator ==(LabelArgs left, LabelArgs right)
            {
                return Equals(left, right);
            }

            public static bool operator !=(LabelArgs left, LabelArgs right)
            {
                return !Equals(left, right);
            }

            public string Text { get; private set; }
            public string TextColor { get; private set; }

            public LabelArgs(string text, string textColor)
            {
                this.Text = text;
                this.TextColor = textColor;
            }
        }

        public object[] GetArgs()
        {
            switch (this.Type)
            {
                case ForegroundType.Normal:
                    return new object[0];
                case ForegroundType.Portal:
                    return new object[] { (uint)this.Morph, this.PortalId, this.PortalTarget };
                case ForegroundType.Label:
                    return new object[] { this.Text, this.TextColor };
                default:
                    return new[] { this._args };
            }
        }
    }
}