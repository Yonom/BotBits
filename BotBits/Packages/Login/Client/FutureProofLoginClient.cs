using System.Threading.Tasks;
using EE.FutureProof;
using JetBrains.Annotations;
using PlayerIOClient;

namespace BotBits
{
    public class FutureProofLoginClient : LoginClient
    {
        private const int CurrentVersion = 218;
        
        public FutureProofLoginClient([NotNull] ConnectionManager connectionManager, [NotNull] Client client) : base(connectionManager, client)
        {
        }

        protected override Task Attach(ConnectionManager connectionManager, Connection connection, ConnectionArgs args, int? version)
        {
            var versionLoader = version.HasValue 
                ? TaskHelper.FromResult(version.Value) 
                : LoginUtils.GetVersionAsync(this.Client);

            return versionLoader.Then(v =>
            {
                connectionManager.AttachConnection(connection.FutureProof(CurrentVersion, v.Result), args);
            });
        }
    }
}
