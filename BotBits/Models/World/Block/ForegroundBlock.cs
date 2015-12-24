using System;
using System.Diagnostics;

namespace BotBits
{
    [DebuggerDisplay("Id = {Id}")]
    public struct ForegroundBlock : IEquatable<ForegroundBlock>
    {
        public bool Equals(ForegroundBlock other)
        {
            return Equals(this._args, other._args) && this.Id == other.Id && this.Type == other.Type;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is ForegroundBlock && this.Equals((ForegroundBlock) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = (this._args != null ? this._args.GetHashCode() : 0);
                hashCode = (hashCode*397) ^ (int) this.Id;
                hashCode = (hashCode*397) ^ (int) this.Type;
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

        public ForegroundBlock(Foreground.Id id)
        {
            var type = WorldUtils.GetForegroundType(id);
            if (WorldUtils.GetBlockArgsType(type) != BlockArgsType.None)
                throw new ArgumentException("The given block is missing required arguments.", "id");

            this._args = null;
            this.Type = ForegroundType.Normal;
            this.Id = id;
        }


        public ForegroundBlock(Foreground.Id id, uint args)
        {
            var type = WorldUtils.GetForegroundType(id);
            switch (WorldUtils.GetBlockArgsType(type))
            {
                case BlockArgsType.Number:
                    this._args = args;
                    break;
                case BlockArgsType.SignedNumber:
                    this._args = (int) args;
                    break;
                default:
                    throw new ArgumentException("Invalid arguments for the specified block.", "id");
            }
            this.Type = type;
            this.Id = id;
        }

        public ForegroundBlock(Foreground.Id id, string text)
        {
            var type = WorldUtils.GetForegroundType(id);
            if (WorldUtils.GetBlockArgsType(type) != BlockArgsType.String)
                throw new ArgumentException("Invalid arguments for the specified block.", "id");

            this._args = text;
            this.Type = type;
            this.Id = id;
        }

        public ForegroundBlock(Foreground.Id id, string text, string textColor)
        {
            var type = WorldUtils.GetForegroundType(id);
            if (WorldUtils.GetBlockArgsType(type) != BlockArgsType.Label)
                throw new ArgumentException("Invalid arguments for the specified block.", "id");

            this._args = new LabelArgs(text, textColor);
            this.Type = type;
            this.Id = id;
        }

        public ForegroundBlock(Foreground.Id id, uint portalId, uint portalTarget, Morph.Id portalRotation)
        {
            var type = WorldUtils.GetForegroundType(id);
            if (WorldUtils.GetBlockArgsType(type) != BlockArgsType.Portal)
                throw new ArgumentException("The given block is not a portal.", "id");

            this._args = new PortalArgs(portalId, portalTarget, portalRotation);
            this.Type = ForegroundType.Portal;
            this.Id = id;
        }

        public ForegroundBlock(Foreground.Id id, int portalId, int portalTarget, Morph.Id portalRotation)
            : this(id, (uint) portalId, (uint) portalTarget, portalRotation)
        {
        }

        public ForegroundBlock(Foreground.Id id, int goal)
            : this(id, (uint) goal)
        {
        }

        public ForegroundBlock(Foreground.Id id, bool enabled)
            : this(id, enabled ? 1 : 0)
        {
        }

        public ForegroundBlock(Foreground.Id id, Morph.Id morph)
            : this(id, (uint) morph)
        {
        }

        /// <summary>
        ///     Gets the block.
        /// </summary>
        /// <value>
        ///     The block.
        /// </value>
        public Foreground.Id Id { get; }

        /// <summary>
        ///     Gets the type.
        /// </summary>
        /// <value>
        ///     The type.
        /// </value>
        public ForegroundType Type { get; }

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
                        return (string) this._args;
                    case ForegroundType.Label:
                        return this.GetLabelArgs().Text;
                    default:
                        throw new InvalidOperationException(
                            "This property can only be accessed on label or text blocks.");
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

                return (uint) this._args != 0;
            }
        }

        /// <summary>
        ///     Gets the goal. (Only on goal blocks)
        /// </summary>
        /// <value>
        ///     The goal.
        /// </value>
        /// <exception cref="System.InvalidOperationException">This property can only be accessed on goal blocks.</exception>
        public uint Goal
        {
            get
            {
                if (this.Type != ForegroundType.Goal && this.Type != ForegroundType.ToggleGoal)
                    throw new InvalidOperationException("This property can only be accessed on goal blocks.");

                return (uint) this._args;
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

                return (string) this._args;
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
                    case ForegroundType.Team:
                        return (Morph.Id) (uint) this._args;


                    case ForegroundType.Note:
                        return (Morph.Id) (int) this._args;

                    default:
                        throw new InvalidOperationException("This property can only be accessed on morphable blocks.");
                }
            }
        }

        private PortalArgs GetPortalArgs()
        {
            return (PortalArgs) this._args;
        }

        private LabelArgs GetLabelArgs()
        {
            return (LabelArgs) this._args;
        }

        private class PortalArgs : IEquatable<PortalArgs>
        {
            public PortalArgs(uint portalId, uint portalTarget, Morph.Id portalRotation)
            {
                this.PortalId = portalId;
                this.PortalTarget = portalTarget;
                this.PortalRotation = portalRotation;
            }

            public uint PortalId { get; }
            public uint PortalTarget { get; }
            public Morph.Id PortalRotation { get; }

            public bool Equals(PortalArgs other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return this.PortalId == other.PortalId && this.PortalTarget == other.PortalTarget &&
                       this.PortalRotation == other.PortalRotation;
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return this.Equals((PortalArgs) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    var hashCode = (int) this.PortalId;
                    hashCode = (hashCode*397) ^ (int) this.PortalTarget;
                    hashCode = (hashCode*397) ^ (int) this.PortalRotation;
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
        }

        private class LabelArgs : IEquatable<LabelArgs>
        {
            public LabelArgs(string text, string textColor)
            {
                this.Text = text;
                this.TextColor = textColor;
            }

            public string Text { get; }
            public string TextColor { get; }

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
                return this.Equals((LabelArgs) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return ((this.Text != null ? this.Text.GetHashCode() : 0)*397) ^
                           (this.TextColor != null ? this.TextColor.GetHashCode() : 0);
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
        }

        public object[] GetArgs()
        {
            switch (this.Type)
            {
                case ForegroundType.Normal:
                    return new object[0];
                case ForegroundType.Portal:
                    return new object[] {(uint) this.Morph, this.PortalId, this.PortalTarget};
                case ForegroundType.Label:
                    return new object[] {this.Text, this.TextColor};
                default:
                    return new[] {this._args};
            }
        }
    }
}