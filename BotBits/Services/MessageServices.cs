using System;
using JetBrains.Annotations;

namespace BotBits
{
    public static class MessageServices
    {
        [ThreadStatic]
        private static bool _skipQueues;

        [ThreadStatic]
        private static bool _noChecks;

        [ThreadStatic]
        private static bool _instantSend;

        /// <summary>
        ///     Gets a value indicating whether SendMessages raised on this thread skip queues.
        /// </summary>
        /// <value>
        ///     <c>true</c> if skip queues is enabled; otherwise, <c>false</c>.
        /// </value>
        public static bool SkipQueues => _skipQueues;

        /// <summary>
        ///     Gets a value indicating whether SendMessages raised on this thread are sent without any redundancy checks.
        /// </summary>
        /// <value>
        ///     <c>true</c> if force send is enabled; otherwise, <c>false</c>.
        /// </value>
        public static bool NoChecks => _noChecks;

        /// <summary>
        ///     Gets a value indicating whether SendMessages raised on this thread are sent without entering any queues.
        /// </summary>
        /// <value>
        ///     <c>true</c> if instant send is enabled; otherwise, <c>false</c>.
        /// </value>
        public static bool InstantSend => _instantSend;

        /// <summary>
        ///     Enables the skip queue feature for SendMessages that are sent using the given callback.
        /// </summary>
        /// <param name="task">The task.</param>
        public static void WithSkipsQueue([InstantHandle] Action task)
        {
            var oldvalue = _skipQueues;
            _skipQueues = true;
            task();
            _skipQueues = oldvalue;
        }

        /// <summary>
        ///     Enables the force send feature for SendMessages that are sent using the given callback.
        /// </summary>
        /// <param name="task">The task.</param>
        public static void WithNoChecks([InstantHandle] Action task)
        {
            var oldvalue = _noChecks;
            _noChecks = true;
            task();
            _noChecks = oldvalue;
        }

        /// <summary>
        ///     Enables the instant send feature for SendMessages that are sent using the given callback.
        /// </summary>
        /// <param name="task">The task.</param>
        public static void WithInstantSend([InstantHandle] Action task)
        {
            var oldvalue = _instantSend;
            _instantSend = true;
            task();
            _instantSend = oldvalue;
        }
    }
}