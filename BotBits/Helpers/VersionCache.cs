using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;

namespace BotBits
{
    public class VersionCache
    {
        private int? _version;

        public Task<VersionLoginClient> GetWithCachedVersionAsync(LoginClient client)
        {
            if (this._version == null)
            {
                return client.WithAutomaticVersionAsync().Then(task =>
                {
                    this._version = task.Result.Version;
                    return task;
                }).ToSafeTask();
            }

            var tcs = new TaskCompletionSource<VersionLoginClient>();
            tcs.SetResult(client.WithVersion(this._version.Value));
            return tcs.Task;
        }

        public VersionLoginClient GetWithCachedVersion(LoginClient client)
        {
            return this.GetWithCachedVersionAsync(client).GetResultEx();
        }
    }
}
