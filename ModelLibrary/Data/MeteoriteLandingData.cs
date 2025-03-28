using System.Reflection;
using System.Text;
using System.Text.Json;
using ModelLibrary.GRPC;

namespace ModelLibrary.Data;

public static class MeteoriteLandingData
{
    static string meteoriteLandingsJson;
    static List<REST.MeteoriteLanding> restMeteoriteLandings;
    static List<GRPC.MeteoriteLanding> grpcMeteoriteLandings;
    static GRPC.MeteoriteLandingList grpcMeteoriteLandingList;

    public static string MeteoriteLandingsJson
    {
        get
        {
            if (meteoriteLandingsJson != null)
            {
                return meteoriteLandingsJson;
            }
            
            var assembly = Assembly.GetExecutingAssembly();
            var resourceStream = assembly.GetManifestResourceStream("ModelLibrary.Data.MeteoriteLandings.json");

            using var reader = new StreamReader(resourceStream, Encoding.UTF8);
            meteoriteLandingsJson = reader.ReadToEnd();

            return meteoriteLandingsJson;

        }
    }


    public static List<REST.MeteoriteLanding> RestMeteoriteLandings
    {
        get
        {
            if (restMeteoriteLandings != null)
            {
                return restMeteoriteLandings;
            }
            restMeteoriteLandings = JsonSerializer.Deserialize<List<REST.MeteoriteLanding>>(MeteoriteLandingsJson);
            return restMeteoriteLandings;
        }
    }


    public static List<GRPC.MeteoriteLanding> GrpcMeteoriteLandings
    {
        get
        {
            if (grpcMeteoriteLandings != null)
            {
                return grpcMeteoriteLandings;
            }
            grpcMeteoriteLandings = JsonSerializer.Deserialize<List<GRPC.MeteoriteLanding>>(MeteoriteLandingsJson, new JsonSerializerOptions
            {
                Converters = { new ProtobufJsonConverter() }
            });

            return grpcMeteoriteLandings;
        }
    }


    public static GRPC.MeteoriteLandingList GrpcMeteoriteLandingList
    {
        get
        {
            if (grpcMeteoriteLandingList != null)
            {
                return grpcMeteoriteLandingList;
            }
            grpcMeteoriteLandingList = new GRPC.MeteoriteLandingList();
            grpcMeteoriteLandingList.MeteoriteLandings.AddRange(GrpcMeteoriteLandings);

            return grpcMeteoriteLandingList;
        }
    }
}