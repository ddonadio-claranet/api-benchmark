using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using ModelLibrary.REST;

namespace Benchmark;

public class RestClient
{
    private static readonly HttpClient client = new();

    public async Task<string> GetSmallPayloadAsync()
    {
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        return await client.GetStringAsync("http://localhost:5000/api/MeteoriteLandings");
    }

    public async Task<List<MeteoriteLanding>> GetLargePayloadAsync()
    {
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var meteoriteLandingsString = await client.GetStringAsync("http://localhost:5000/api/MeteoriteLandings/LargePayload");

        return JsonSerializer.Deserialize<List<MeteoriteLanding>>(meteoriteLandingsString);
    }

    public async Task<string> PostLargePayloadAsync(List<MeteoriteLanding> meteoriteLandings)
    {
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var response = await client.PostAsJsonAsync("http://localhost:5000/api/MeteoriteLandings/LargePayload", meteoriteLandings);

        return await response.Content.ReadAsStringAsync();
    }
}