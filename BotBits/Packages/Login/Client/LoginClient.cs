using System.Threading;
using System.Threading.Tasks;
using BotBits.Events;
using PlayerIOClient;

namespace BotBits
{
    public class LoginClient : ILoginClient
    {
        private readonly Task<PlayerData> _argsAsync;
        private readonly BotBitsClient _botBitsClient;

        public DatabaseHandle Database => new DatabaseHandle(this.Client);

        internal LoginClient(BotBitsClient botBitsClient, Client client)
        {
            PlayerIOServices.DefaultClient = client;

            this._botBitsClient = botBitsClient;
            this.Client = client;
            this._argsAsync = this.Database.GetMyPlayerDataAsync();
        }

        public string ConnectUserId => this.Client.ConnectUserId;

        public Client Client { get; }

        public Task<PlayerData> GetPlayerDataAsync()
        {
            return this._argsAsync
                .Then(handle => handle.Result)
                .ToSafeTask();
        }

        public Task<LobbyItem[]> GetLobbyAsync()
        {
            return this.WithAutomaticVersionAsync()
                .Then(task => task.Result.GetLobbyAsync())
                .ToSafeTask();
        }

        public Task CreateOpenWorldAsync(string roomId, string name, CancellationToken ct)
        {
            return this.WithAutomaticVersionAsync()
                .Then(task => task.Result.CreateOpenWorldAsync(roomId, name, ct))
                .ToSafeTask();
        }

        public Task CreateJoinRoomAsync(string roomId, CancellationToken ct)
        {
            return this.WithAutomaticVersionAsync()
                .Then(task => task.Result.CreateJoinRoomAsync(roomId, ct))
                .ToSafeTask();
        }

        public Task JoinRoomAsync(string roomId, CancellationToken ct)
        {
            return this.Client.Multiplayer
                .JoinRoomAsync(roomId, null)
                .Then(task => this.InitConnection(roomId, null, task.Result, ct))
                .ToSafeTask();
        }

        public VersionLoginClient WithVersion(int version)
        {
            return new VersionLoginClient(this, version);
        }

        public Task<VersionLoginClient> WithAutomaticVersionAsync()
        {
            return this.Database.GetVersionDataAsync()
                .Then(task => this.WithVersion(task.Result.Version))
                .ToSafeTask();
        }

        internal Task InitConnection(string roomId, int? version, Connection conn, CancellationToken ct)
        {
            var joinTask = this.CompleteJoinAsync(ct);
            return this._argsAsync
                .Then(task => this.Attach(ConnectionManager.Of(this._botBitsClient), conn, 
                    new ConnectionArgs(this.ConnectUserId, roomId, task.Result, this.Database), version))
                .Then(task => joinTask)
                .Then(task => { if (task.IsCanceled) ConnectionManager.Of(this._botBitsClient).Connection.Disconnect(); })
                .ToSafeTask();
        }

        internal Task CompleteJoinAsync(CancellationToken ct)
        {
            var cts = new CancellationTokenSource();
            var tcs = new TaskCompletionSource<bool>();
            ct.Register(() =>
            {
                cts.Cancel();
                tcs.TrySetCanceled();
            });
            
            JoinCompleteEvent.Of(this._botBitsClient).WaitOneAsync(cts.Token).ContinueWith(task =>
            {
                if (task.IsCanceled) return;
                cts.Cancel();

                tcs.TrySetResult(true);
            }, CancellationToken.None);
            JoinFailureEvent.Of(this._botBitsClient).WaitOneAsync(cts.Token).ContinueWith(task =>
            {
                if (task.IsCanceled) return;
                cts.Cancel();

                tcs.TrySetException(new JoinException(task.Result.Title, task.Result.Reason));
            }, CancellationToken.None);

            return tcs.Task;
        }

        protected virtual Task Attach(ConnectionManager connectionManager, Connection connection, ConnectionArgs args, int? version)
        {
            connectionManager.AttachConnection(connection, args);
            return TaskHelper.FromResult(true);
        }
    }
}