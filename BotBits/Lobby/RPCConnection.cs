using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayerIOClient;

namespace BotBits.Lobby
{
    public abstract class RPCConnection : IDisposable
    {
        protected RPCConnection(IConnection connection)
        {
            
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
