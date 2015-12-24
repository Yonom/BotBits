using System.Threading;

namespace BotBits.Nito.Async
{
    public sealed class BotBitsSynchronizationContext : SynchronizationContext
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="BotBitsSynchronizationContext" /> class by using the
        ///     specified <see cref="BotBitsSynchronizationContext.ActionDispatcher" />.
        /// </summary>
        /// <param name="actionDispatcher">The action queue to associate with this <see cref="BotBits" />.</param>
        internal BotBitsSynchronizationContext(ActionDispatcher actionDispatcher)
        {
            this.ActionDispatcher = actionDispatcher;
        }

        /// <summary>
        ///     Gets or sets the action queue for the thread to synchronize with.
        /// </summary>
        internal ActionDispatcher ActionDispatcher { get; set; }

        /// <summary>
        ///     Creates a copy of this <see cref="BotBitsSynchronizationContext" />.
        /// </summary>
        /// <returns>The copy of this synchronization context.</returns>
        /// <threadsafety>This method may be called by any thread at any time.</threadsafety>
        public override SynchronizationContext CreateCopy()
        {
            return new BotBitsSynchronizationContext(this.ActionDispatcher);
        }

        /// <summary>
        ///     Invokes the callback in the synchronization context asynchronously. The callback is placed in the action queue.
        /// </summary>
        /// <param name="d">The delegate to call.</param>
        /// <param name="state">The object passed to the delegate.</param>
        /// <threadsafety>This method may be called by any thread at any time.</threadsafety>
        public override void Post(SendOrPostCallback d, object state)
        {
            this.ActionDispatcher.QueueAction(() => d(state));
        }

        /// <summary>
        ///     Invokes the callback in the synchronization context synchronously. The callback is placed in the action queue.
        /// </summary>
        /// <param name="d">The delegate to call.</param>
        /// <param name="state">The object passed to the delegate.</param>
        /// <remarks>
        ///     <para>
        ///         This method cannot be called from the thread running the action queue associated with this synchronization
        ///         context.
        ///     </para>
        /// </remarks>
        public override void Send(SendOrPostCallback d, object state)
        {
            // ReSharper disable once AccessToDisposedClosure
            using (var evt = new ManualResetEvent(false))
            {
                this.ActionDispatcher.QueueAction(() =>
                {
                    d(state);
                    evt.Set();
                });
                evt.WaitOne();
            }
        }
    }
}