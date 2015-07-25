using System;
using System.Threading;
using JetBrains.Annotations;
using PlayerIOClient;

namespace BotBits.SendMessages
{
    /// <summary>
    ///     Class Send Event
    /// </summary>
    public abstract class SendMessage<T> where T : SendMessage<T>
    {
        private int _sendCount;

        internal SendMessage()
        {
            var a = typeof(T);
            if (a != this.GetType())
                throw new InvalidOperationException("SendMessages must inherit SendMessage<T> of their own type!");
            if (!a.IsSealed)
                throw new InvalidOperationException("SendMessages must be marked as sealed.");
        }

        /// <summary>
        /// Gets or sets a value indicating whether this message skips the send queue.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this message skips the send queue; otherwise, <c>false</c>.
        /// </value>
        public bool SkipsQueue { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether this message checks for redundancies before being sent.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this message has redundancy checks disabled; otherwise, <c>false</c>.
        /// </value>
        public bool NoChecks { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether this message is instantly sent without entering the queue.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this message does not enter the queue; otherwise, <c>false</c>.
        /// </value>
        public bool InstantSend { get; private set; }


        /// <summary>
        /// Gets the number of times SendIn was called on this message.
        /// </summary>
        /// <value>
        /// The send count.
        /// </value>
        public int SendCount
        {
            get { return this._sendCount; }
        }

        /// <summary>
        ///     Gets the PlayerIO message representing the data in this <see cref="SendMessage{T}" />.
        /// </summary>
        /// <returns></returns>
        protected abstract Message GetMessage();
        
        internal void Send(IConnection connection)
        {
            connection.Send(this.GetMessage());
        }

        public virtual void SendIn(BotBitsClient client)
        {
            Interlocked.Increment(ref _sendCount); 
            this.SkipsQueue |= MessageServices.SkipQueues;
            this.NoChecks |= MessageServices.NoChecks;
            this.InstantSend |= MessageServices.InstantSend;

            if (this.InstantSend)
            {
                Of(client).SendMessage((T)this, ConnectionManager.Of(client).Connection);
            }
            else
            {
                Of(client).Enqueue((T)this);
            }
        }

        [Pure]
        public static MessageQueue<T> Of([NotNull] BotBitsClient client)
        {
            return MessageSender
                .Of(client)
                .GetQueue<T>();
        } 
    }
}