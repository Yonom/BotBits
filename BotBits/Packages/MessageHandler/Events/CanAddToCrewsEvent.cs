using System.Collections.Generic;
using PlayerIOClient;

namespace BotBits.Events
{
    [ReceiveEvent("canAddToCrews")]
    public sealed class CanAddToCrewsEvent : ReceiveEvent<CanAddToCrewsEvent>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CanAddToCrewsEvent" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="client"></param>
        internal CanAddToCrewsEvent(BotBitsClient client, Message message)
            : base(client, message)
        {
            this.Crews = new List<Crew>();
            
            for (uint i = 0; i <= message.Count - 1; i += 2)
            {
                var id = message.GetString(i);
                var name = message.GetString(i + 1);

                this.Crews.Add(new Crew(id, name));
            }
        }
        public List<Crew> Crews { get; set; }
    }
}
