using Grpc.Core;
using ModelLibrary.Data;
using ModelLibrary.GRPC;


namespace gRpcApi.Services;

public class MeteoriteLandingService(ILogger<MeteoriteLandingService> logger)
    : MeteoriteLandingsService.MeteoriteLandingsServiceBase
{
    private readonly ILogger<MeteoriteLandingService> _logger = logger;
    
    
    public override async Task GetLargePayload(EmptyRequest request, IServerStreamWriter<MeteoriteLanding> responseStream, ServerCallContext context)
    {
        foreach (var meteoriteLanding in MeteoriteLandingData.GrpcMeteoriteLandings)
        {
            await responseStream.WriteAsync(meteoriteLanding);
        }
    }

    public override Task<MeteoriteLandingList> GetLargePayloadAsList(EmptyRequest request, ServerCallContext context)
    {
        return Task.FromResult(MeteoriteLandingData.GrpcMeteoriteLandingList);
    }

    public override Task<StatusResponse> PostLargePayload(MeteoriteLandingList request, ServerCallContext context)
    {
        return Task.FromResult(new StatusResponse { Status = "SUCCESS" });
    }
}