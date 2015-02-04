using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayerIOClient;

namespace BotBits
{
    public class PlayerIOConnectionAdapter : IConnection, IDisposable
    {
        private readonly Connection _connection;

        public PlayerIOConnectionAdapter(Connection connection)
        {
            this._connection = connection;
        }

        public void Disconnect()
        {
           this._connection.Disconnect();
        }

        public void Send(Message message)
        {
            this._connection.Send(message);
        }

        public bool Connected
        {
            get { return this._connection.Connected; }
        }

        public event MessageReceivedEventHandler OnMessage
        {
            add { this._connection.OnMessage += value; }
            remove { this._connection.OnMessage -= value; }
        }
        public event DisconnectEventHandler OnDisconnect
        {
            add { this._connection.OnDisconnect += value; }
            remove { this._connection.OnDisconnect -= value; }
        }

        public void Dispose()
        {
            this._connection.Disconnect();
        }
    }
}
