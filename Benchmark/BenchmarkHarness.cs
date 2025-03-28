using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Validators;
using ModelLibrary.Data;

namespace Benchmark;

[AsciiDocExporter]
[CsvExporter]
[HtmlExporter]
public class BenchmarkHarness
{
    [Params(100, 200)]
    public int IterationCount;

    readonly RestClient restClient = new RestClient();
    readonly GrpcClient grpcClient = new();

    [Benchmark]
    public async Task RestGetSmallPayloadAsync()
    {
        for (var i = 0; i < IterationCount; i++)
        {
            await restClient.GetSmallPayloadAsync();
        }
    }

    [Benchmark]
    public async Task RestGetLargePayloadAsync()
    {
        for (var i = 0; i < IterationCount; i++)
        {
            await restClient.GetLargePayloadAsync();
        }
    }

    [Benchmark]
    public async Task RestPostLargePayloadAsync()
    {
        for (var i = 0; i < IterationCount; i++)
        {
            await restClient.PostLargePayloadAsync(MeteoriteLandingData.RestMeteoriteLandings);
        }
    }

    [Benchmark]
    public async Task GrpcGetSmallPayloadAsync()
    {
        for (var i = 0; i < IterationCount; i++)
        {
            await grpcClient.GetSmallPayloadAsync();
        }
    }

    [Benchmark]
    public async Task GrpcStreamLargePayloadAsync()
    {
        for (var i = 0; i < IterationCount; i++)
        {
            await grpcClient.StreamLargePayloadAsync();
        }
    }

    [Benchmark]
    public async Task GrpcGetLargePayloadAsListAsync()
    {
        for (var i = 0; i < IterationCount; i++)
        {
            await grpcClient.GetLargePayloadAsListAsync();
        }
    }

    [Benchmark]
    public async Task GrpcPostLargePayloadAsync()
    {
        for (var i = 0; i < IterationCount; i++)
        {
            await grpcClient.PostLargePayloadAsync(MeteoriteLandingData.GrpcMeteoriteLandingList);
        }
    }
}

public class AllowNonOptimized : ManualConfig
{
    public AllowNonOptimized()
    {
        AddValidator(JitOptimizationsValidator.DontFailOnError);

        AddLogger(DefaultConfig.Instance.GetLoggers().ToArray());
        AddExporter(DefaultConfig.Instance.GetExporters().ToArray());
        AddColumnProvider(DefaultConfig.Instance.GetColumnProviders().ToArray());
    }
}
