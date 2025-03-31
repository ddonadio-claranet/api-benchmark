using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using ModelLibrary.REST;

namespace Benchmark;

public class RestWithGzipClient
{
    private static readonly HttpClient client = new();

    const string requestUri = "http://localhost:5089/api/MeteoriteLandings";
    
    public async Task<string> GetSmallPayloadAsync()
    {
        SetupCall();

        return await client.GetStringAsync(requestUri);
    }



    public async Task<List<MeteoriteLanding>> GetLargePayloadAsync()
    {
        SetupCall();

        var meteoriteLandingsString = await client.GetStringAsync($"{requestUri}/LargePayload");

        return JsonSerializer.Deserialize<List<MeteoriteLanding>>(meteoriteLandingsString);
    }

    public async Task<string> PostLargePayloadAsync(List<MeteoriteLanding> meteoriteLandings)
    {
        SetupCall();

        var response = await client.PostAsJsonAsync($"{requestUri}/LargePayload", meteoriteLandings);

        return await response.Content.ReadAsStringAsync();
    }
    
    private static void SetupCall()
    {
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
}