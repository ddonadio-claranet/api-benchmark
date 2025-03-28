using Grpc.Net.Client;
using ModelLibrary.GRPC;

namespace Benchmark;

public class GrpcClient
{
    private readonly GrpcChannel channel;
    private readonly MeteoriteLandingsService.MeteoriteLandingsServiceClient client;

    public GrpcClient()
    {
        channel = GrpcChannel.ForAddress("http://localhost:5231");
        client = new MeteoriteLandingsService.MeteoriteLandingsServiceClient(channel);
    }
    public async Task<string> GetSmallPayloadAsync()
    {
        return (await client.GetVersionAsync(new EmptyRequest())).ApiVersion;
    }

    public async Task<List<MeteoriteLanding>> StreamLargePayloadAsync()
    {
        var meteoriteLandings = new List<MeteoriteLanding>();

        var response = client.GetLargePayload(new EmptyRequest()).ResponseStream;
        while (await response.MoveNext(CancellationToken.None))
        {
            meteoriteLandings.Add(response.Current);
        }

        return meteoriteLandings;
    }

    public async Task<IList<MeteoriteLanding>> GetLargePayloadAsListAsync() 
        => (await client.GetLargePayloadAsListAsync(new EmptyRequest())).MeteoriteLandings;

    public async Task<string> PostLargePayloadAsync(MeteoriteLandingList meteoriteLandings) 
        => (await client.PostLargePayloadAsync(meteoriteLandings)).Status;
}