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
        const string PmPrefix = "* ";
        const string PmSuffix = " > you";
        const string PmSendPrefix = "* you > ";

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
                    }
                }
                else if (this.Title.StartsWith(PmPrefix) && this.Title.EndsWith(PmSuffix))
                {
                    return WriteType.ReceivedPrivateMessage;
                }
                else if (this.Title.StartsWith(PmSendPrefix))
                {
                    return WriteType.SentPrivateMessage;
                }

                return WriteType.Unrecognized;
            }
        }

        public string GetUser()
        {
            switch (this.Type)
            {
                case WriteType.ReceivedPrivateMessage:
                    return this.Title.Substring(PmPrefix.Length, this.Title.Length - PmPrefix.Length - PmSuffix.Length);
                case WriteType.SentPrivateMessage:
                    return this.Title.Substring(PmSendPrefix.Length);

                default:
                    throw new InvalidOperationException();
            }
        }
    }
}