using System;
using System.Diagnostics;
using System.Threading;

namespace BotBits
{
    internal sealed class SendTimer : IDisposable
    {
        private readonly Timer _myTimer;
        private readonly Stopwatch _sw = Stopwatch.StartNew();
        private double _sendTimerFrequency;
        private double _offset;

        public SendTimer(double sendTimerFrequency)
        {
            this._sendTimerFrequency = sendTimerFrequency;
            this._myTimer = new Timer(this.TimerCallback, null, 0, 15);
        }

        public void Dispose()
        {
            this._myTimer.Dispose();
        }

        /// <summary>
        ///     Occurs when [elapsed].
        /// </summary>
        public event Action<long> Elapsed;


        private void TimerCallback(object state)
        {
            var swTicks = this.GetTicks();
            if (swTicks > 0)
            {
                var ticks = (long)(Math.Floor(swTicks) + this._offset);
                this.Elapsed?.Invoke(ticks);
            }
        }

        private double GetTicks()
        {
            return this._sw.ElapsedMilliseconds * 0.001 * this._sendTimerFrequency;
        }

        public void UpdateFrequency(double sendTimerFrequency)
        {
            var offsetDelta = this.GetTicks();

            this._sw.Reset();
            this._offset += offsetDelta;
            this._sendTimerFrequency = sendTimerFrequency;
            this._sw.Start();
        }
    }
}