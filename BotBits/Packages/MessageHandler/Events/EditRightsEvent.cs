using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when a player receives or loses edit rights.
    ///     NOTE: You receive this even only if you are owner of the world.
    /// </summary>
    /// <seealso cref="PlayerEvent{T}" />
    [ReceiveEvent("editRights")]
    public sealed class EditRightsEvent : PlayerEvent<EditRightsEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="EditRightsEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal EditRightsEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            AllowEdit = message.GetBoolean(1);
        }

        /// <summary>
        ///     Gets or sets a value indicating whether player is now allowed to edit.
        /// </summary>
        /// <value><c>true</c> if player is now allowed to edit; otherwise, <c>false</c>.</value>
        public bool AllowEdit { get; set; }
    }
}