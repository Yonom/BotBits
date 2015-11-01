using System;

namespace BotBits
{
    public abstract class EventListenerPackage<T> : Package<T> where T : EventListenerPackage<T>, new()
    {
        protected EventListenerPackage()
        {
            this.InitializeFinish += this.EventListenerPackage_InitializeFinish;
        }

        private void EventListenerPackage_InitializeFinish(object sender, EventArgs e)
        {
            EventLoader
                .Of(this.BotBits)
                .Load(this);
        }
    }
}