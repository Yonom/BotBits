using System.Linq;
using JetBrains.Annotations;
using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Class Block Send Event
    /// </summary>
    public sealed class PlaceSendMessage : RoomTokenSendMessage<PlaceSendMessage>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PlaceSendMessage" /> class.
        /// </summary>
        /// <param name="layer">The layer.</param>
        /// <param name="x">The x-coordinate.</param>
        /// <param name="y">The y-coordinate.</param>
        /// <param name="id">The block id.</param>
        /// <param name="args">The block arguments</param>
        public PlaceSendMessage(Layer layer, int x, int y, int id, [NotNull] params object[] args)
        {
            this.Layer = layer;
            this.X = x;
            this.Y = y;
            this.Id = id;
            this.Args = args;
        }

        /// <summary>
        ///     Gets or sets the block.
        /// </summary>
        /// <value>
        ///     The block.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        ///     Gets or sets the arguments.
        /// </summary>
        /// <value>
        ///     The arguments.
        /// </value>
        public object[] Args { get; set; }

        /// <summary>
        ///     Gets or sets the layer.
        /// </summary>
        /// <value>
        ///     The layer.
        /// </value>
        public Layer Layer { get; set; }

        /// <summary>
        ///     Gets or sets the x-coordinate.
        /// </summary>
        /// <value>
        ///     The x-coordinate.
        /// </value>
        public int X { get; set; }

        /// <summary>
        ///     Gets or sets the y-coordinate.
        /// </summary>
        /// <value>
        ///     The y-coordinate.
        /// </value>
        public int Y { get; set; }

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected override Message GetMessage()
        {
            var msgArgs = new object[] {(int) this.Layer, this.X, this.Y, this.Id}.Concat(this.Args).ToArray();
            return Message.Create(this.RoomToken, msgArgs);
        }
    }
}