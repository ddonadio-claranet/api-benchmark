using Grpc.Core;
using ModelLibrary.GRPC;

namespace gRpcApi.Services;

public class MeteoriteLandingService
{
    private readonly Server server = new()
    {
        Services = { MeteoriteLandingsService.BindService(new MeteoriteLandingsServiceImpl()) },
        Ports = { new ServerPort("localhost", 6000, ServerCredentials.Insecure) }
    };

    public void Start()
    {
        server.Start();
    }

    public async Task ShutdownAsync()
    {
        await server.ShutdownAsync();
    }
}