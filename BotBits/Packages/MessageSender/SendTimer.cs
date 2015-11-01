using System;
using System.Diagnostics;
using System.Threading;

namespace BotBits
{
    internal class SendTimer : IDisposable
    {
        private readonly Timer _myTimer;
        private readonly Stopwatch _sw = Stopwatch.StartNew();

        public SendTimer()
        {
            this._myTimer = new Timer(this.TimerCallback, null, 0, 15);
        }

        public void Dispose()
        {
            this._myTimer.Dispose();
        }

        /// <summary>
        ///     Occurs when [elapsed].
        /// </summary>
        public event Action<int> Elapsed;

        protected virtual void OnElapsed(int obj)
        {
            var handler = this.Elapsed;
            if (handler != null) handler(obj);
        }

        private void TimerCallback(object state)
        {
            var ticks = (int) Math.Floor(this._sw.ElapsedMilliseconds*.0965);
            this.OnElapsed(ticks);
        }
    }
}