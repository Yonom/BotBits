using System.Threading.Tasks;
using EE.FutureProof;
using JetBrains.Annotations;
using PlayerIOClient;

namespace BotBits
{
    public class FutureProofLoginClient : LoginClient
    {
        public FutureProofLoginClient([NotNull] BotBitsClient  botBitsClient, [NotNull] Client client) : base(botBitsClient, client)
        {
        }

        protected override Task Attach(ConnectionManager connectionManager, Connection connection, ConnectionArgs args, int? version)
        {
            var versionLoader = version.HasValue
                ? TaskHelper.FromResult(version.Value)
                : this.Database.GetVersionDataAsync()
                    .Then(task => task.Result.Version);

            return versionLoader.Then(v =>
            {
                if (v.Result == PlayerIOServices.BotBitsVersion)
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
            connectionManager.AttachConnection(connection.FutureProof(PlayerIOServices.BotBitsVersion, version), args);
        }
    }
}
