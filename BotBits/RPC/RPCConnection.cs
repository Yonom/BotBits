using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using PlayerIOClient;

namespace BotBits
{
    public abstract class RPCConnection : IDisposable
    {
        private bool _disposed;
        private PlayerIOConnectionAdapter _connection;

        public IConnection Connection => this._connection;

        public Task<IConnection> ConnectAsync()
        {
            if (this._disposed)
                throw new ObjectDisposedException(nameof(RPCConnection));

            if (this.Connection?.Connected ?? false)
                return TaskHelper.FromResult(this.Connection);

            return this.GetConnectionAsync()
                .Then(t =>
                {
                    this._connection = new PlayerIOConnectionAdapter(t.Result);
                    return this.Connection;
                })
                .ToSafeTask();
        }

        public Task<Message> MakeRPCCallAsync(string type, params object[] args)
        {
            return this.MakeRPCCallAsync(Message.Create(type, args));
        }

        public Task<Message> MakeRPCCallAsync(Message request)
        {
            return this.MakeRPCCallAsync(request, request.Type);
        }

        public Task<Message> MakeRPCCallAsync(Message request, params string[] expectedResponseTypes)
        {
            return this.MakeRPCCallAsync(request, CancellationToken.None, expectedResponseTypes);
        }

        public Task<Message> MakeRPCCallAsync(Message request, CancellationToken ct, params string[] expectedResponseTypes)
        {
            return this.ConnectAsync()
                .Then(t =>
                {
                    var connection = this.Connection;

                    var tcs = new TaskCompletionSource<Message>();

                    void Callback(object sender, Message e)
                    {
                        if (expectedResponseTypes.Contains(e.Type))
                        {
                            tcs.TrySetResult(e);
                            connection.OnMessage -= Callback;
                            connection.OnDisconnect -= Disconnect;
                        }
                    }
                    void Disconnect(object sender, string reason)
                    {
                        tcs.TrySetException(new DisconnectedException("RPC connection lost."));
                        connection.OnMessage -= Callback;
                        connection.OnDisconnect -= Disconnect;
                    }
                    ct.Register(() =>
                    {
                        tcs.TrySetCanceled();
                        connection.OnMessage -= Callback;
                        connection.OnDisconnect -= Disconnect;
                    });

                    connection.OnMessage += Callback;
                    connection.OnDisconnect += Disconnect;
                    if (!connection.Connected) Disconnect(connection, null);
                    else connection.Send(request);

                    return tcs.Task;
                })
                .ToSafeTask();
        }

        protected abstract Task<Connection> GetConnectionAsync();

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._disposed = true;

                this._connection.Dispose();
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
