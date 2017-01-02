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
                if (v.Result == CurrentVersion)
                {
                    base.Attach(connectionManager, connection, args, v.Result);
                }
                else
                {
                    this.FutureProofAttach(connectionManager, connection, args, v.Result);
                }
            });
        }

        // This line is separated into a function to prevent uncessarily loading FutureProof into memory. 
        private void FutureProofAttach(ConnectionManager connectionManager, Connection connection, ConnectionArgs args, int version)
        {
            connectionManager.AttachConnection(connection.FutureProof(CurrentVersion, version), args);
        }
    }
}
