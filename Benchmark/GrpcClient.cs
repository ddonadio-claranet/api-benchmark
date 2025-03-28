using Grpc.Core;
using ModelLibrary.GRPC;

namespace Benchmark;

public class GrpcClient
{
    private readonly Channel channel;
    private readonly MeteoriteLandingsService.MeteoriteLandingsServiceClient client;

    public GrpcClient()
    {
        channel = new Channel("localhost:6000", ChannelCredentials.Insecure);
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
        while (await response.MoveNext())
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