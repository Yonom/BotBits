using System;
using System.Diagnostics;

namespace BotBits
{
    [DebuggerDisplay("Id = {Id}")]
    public struct ForegroundBlock : IEquatable<ForegroundBlock>
    {
        private readonly object _args;

        private ForegroundBlock(Foreground.Id id, BlockArgsType requiredArgsType)
        {
            var type = WorldUtils.GetForegroundType(id);
            var argsType = WorldUtils.GetBlockArgsType(type);
            if (argsType != requiredArgsType)
                throw WorldUtils.GetMissingArgsErrorMessage(argsType, nameof(id));

            this.Id = id;
            this._args = null;
        }

        public ForegroundBlock(Foreground.Id id) : this(id, BlockArgsType.None)
        {
        }

        public ForegroundBlock(Foreground.Id id, uint args)
        {
            var type = WorldUtils.GetForegroundType(id);
            var argsType = WorldUtils.GetBlockArgsType(type);

            this.Id = id;
            switch (argsType)
            {
                case BlockArgsType.Number:
                    this._args = args;
                    break;
                case BlockArgsType.SignedNumber:
                    this._args = (int)args;
                    break;
                default:
                    throw WorldUtils.GetMissingArgsErrorMessage(argsType, nameof(id));
            }
        }

        public ForegroundBlock(Foreground.Id id, string text)
            : this(id, BlockArgsType.String)
        {
            this._args = text;
        }

        public ForegroundBlock(Foreground.Id id, string text, string textColor)
            : this(id, BlockArgsType.Label)
        {
            this._args = new LabelArgs(text, textColor);
            this.Id = id;
        }

        public ForegroundBlock(Foreground.Id id, string text, Morph.Id signColor)
            : this(id, BlockArgsType.Sign)
        {
            this._args = new SignArgs(text, signColor);
            this.Id = id;
        }

        public ForegroundBlock(Foreground.Id id, uint portalId, uint portalTarget, Morph.Id portalRotation)
            : this(id, BlockArgsType.Portal)
        {
            this._args = new PortalArgs(portalId, portalTarget, portalRotation);
            this.Id = id;
        }

        public ForegroundBlock(Foreground.Id id, bool enabled)
            : this(id, enabled ? 1 : 0)
        {
            if (this.Type == ForegroundType.ToggleGoal && enabled)
            {
                throw new ArgumentException("The given block only supports \"false\" or a number.", nameof(enabled));
            }
        }

        public ForegroundBlock(Foreground.Id id, int goal)
            : this(id, (uint)goal)
        {
        }

        public ForegroundBlock(Foreground.Id id, Morph.Id morph)
            : this(id, (uint)morph)
        {
        }

        public ForegroundBlock(Foreground.Id id, int portalId, int portalTarget, Morph.Id portalRotation)
            : this(id, (uint)portalId, (uint)portalTarget, portalRotation)
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
        public ForegroundType Type => WorldUtils.GetForegroundType(this.Id);

        /// <summary>
        ///     Gets the Text. (Only on label / world portal / sign blocks)
        /// </summary>
        /// <value>
        ///     The text.
        /// </value>
        /// <exception cref="System.InvalidOperationException">
        ///     This property can only be accessed on label, world portal and sign
        ///     blocks.
        /// </exception>
        public string Text
        {
            get
            {
                switch (this.Type)
                {
                    case ForegroundType.WorldPortal:
                        return this.GetStringArgs();
                    case ForegroundType.Label:
                        return this.GetLabelArgs()?.Text;
                    case ForegroundType.Sign:
                        return this.GetSignArgs()?.Text;

                    default:
                        throw new InvalidOperationException(
                            "This property can only be accessed on label, world portal and sign blocks.");
                }
            }
        }

        /// <summary>
        ///     Gets the color. (Only on label blocks)
        /// </summary>
        /// <value>
        ///     The color.
        /// </value>
        /// <exception cref="System.InvalidOperationException">This property can only be accessed on label blocks.</exception>
        public string TextColor
        {
            get
            {
                if (this.Type != ForegroundType.Label) throw new InvalidOperationException("This property can only be accessed on label blocks.");

                return this.GetLabelArgs()?.TextColor;
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
                if (this.Type != ForegroundType.Toggle && this.Type != ForegroundType.ToggleGoal) throw new InvalidOperationException("This property can only be accessed on toggle blocks.");

                return this.GetUIntArgs() != 0;
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
                if (this.Type != ForegroundType.Goal && this.Type != ForegroundType.ToggleGoal) throw new InvalidOperationException("This property can only be accessed on goal blocks.");

                return this.GetUIntArgs();
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
                        return (Morph.Id)this.GetUIntArgs();


                    case ForegroundType.Note:
                        return (Morph.Id)this.GetUIntArgs();

                    case ForegroundType.Sign:
                        return this.GetSignArgs()?.SignColor ?? default(Morph.Id);

                    default:
                        throw new InvalidOperationException("This property can only be accessed on morphable blocks.");
                }
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
                if (this.Type != ForegroundType.Portal) throw new InvalidOperationException("This property can only be accessed on Portal blocks.");

                return this.GetPortalArgs()?.PortalId ?? default(uint);
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
                if (this.Type != ForegroundType.Portal) throw new InvalidOperationException("This property can only be accessed on Portal blocks.");

                return this.GetPortalArgs()?.PortalTarget ?? default(uint);
            }
        }

        private string GetStringArgs()
        {
            return this._args as string;
        }

        private uint GetUIntArgs()
        {
            return this._args as uint? ?? default(uint);
        }

        private PortalArgs GetPortalArgs()
        {
            return this._args as PortalArgs;
        }

        private LabelArgs GetLabelArgs()
        {
            return this._args as LabelArgs;
        }

        private SignArgs GetSignArgs()
        {
            return this._args as SignArgs;
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
                return this.Equals((PortalArgs)obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    var hashCode = (int)this.PortalId;
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
                return this.Equals((LabelArgs)obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return ((this.Text?.GetHashCode() ?? 0) * 397) ^
                           (this.TextColor?.GetHashCode() ?? 0);
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

        private class SignArgs : IEquatable<SignArgs>
        {
            public SignArgs(string text, Morph.Id signColor)
            {
                this.Text = text;
                this.SignColor = signColor;
            }

            public string Text { get; }
            public Morph.Id SignColor { get; }

            public bool Equals(SignArgs other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return string.Equals(this.Text, other.Text) && Equals(this.SignColor, other.SignColor);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return this.Equals((SignArgs)obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return ((this.Text?.GetHashCode() ?? 0) * 397) ^ (int)this.SignColor;
                }
            }

            public static bool operator ==(SignArgs left, SignArgs right)
            {
                return Equals(left, right);
            }

            public static bool operator !=(SignArgs left, SignArgs right)
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
                    return new object[] { (uint)this.Morph, this.PortalId, this.PortalTarget };
                case ForegroundType.Label:
                    return new object[] { this.Text, this.TextColor };
                case ForegroundType.Sign:
                    return new object[] { this.Text, (uint)this.Morph };
                default:
                    return new[] { this._args };
            }
        }

        public bool Equals(ForegroundBlock other)
        {
            return Equals(this._args, other._args) && this.Id == other.Id && this.Type == other.Type;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            return obj is ForegroundBlock && this.Equals((ForegroundBlock)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = this._args?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ (int)this.Id;
                hashCode = (hashCode * 397) ^ (int)this.Type;
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
    }
}