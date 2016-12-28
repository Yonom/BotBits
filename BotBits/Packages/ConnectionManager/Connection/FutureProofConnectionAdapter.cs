using System;
using EE.FutureProof;
using PlayerIOClient;

namespace BotBits
{
    public class FutureProofConnectionAdapter : IConnection, IDisposable
    {
        private readonly FutureProofConnection _connection;

        public FutureProofConnectionAdapter(FutureProofConnection connection)
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

        public bool Connected => this._connection.Connected;

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