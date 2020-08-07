using System;
using PlayerIOClient;

namespace BotBits.Events
{
    /// <summary>
    ///     Occurs when a non-player message is received. (System messages, etc.)
    /// </summary>
    [ReceiveEvent("write")]
    public sealed class WriteEvent : ReceiveEvent<WriteEvent>
    {
        const string SystemPrefix = "* SYSTEM";
        const string MagicPrefix = "* MAGIC";

        /// <summary>
        ///     Initializes a new instance of the <see cref="WriteEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal WriteEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.Title = message.GetString(0);
            this.Text = message.GetString(1);
        }

        /// <summary>
        ///     Gets or sets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text { get; set; }

        /// <summary>
        ///     Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        public WriteType Type
        {
            get
            {
                if (this.Title == SystemPrefix)
                {
                    switch (this.Text)
                    {
                        case "You are trying to chat too fast, spamming the chat room is not nice!":
                            return WriteType.ChattingTooFast;
                        case "Everybody Edits is about to get updated. Please save your world now.":
                            return WriteType.IncomingUpdate;
                    }

                    if (this.Text.StartsWith("Final Warning. You have said the same thing"))
                        return WriteType.ChattingTooFast;
                }
                else if (this.Title == MagicPrefix)
                {
                    return WriteType.Magic;
                }

                return WriteType.Unrecognized;
            }
        }

        public string GetUser()
        {
            switch (this.Type)
            {
                case WriteType.Magic:
                    return this.Text.Split(' ')[0].ToLower();

                default:
                    throw new InvalidOperationException();
            }
        }
    }
}