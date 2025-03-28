using gRpcApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();

var app = builder.Build();

app.MapGrpcService<MeteoriteLandingService>();
app.MapGet("/", () => "GRPC MeteoriteLandingServer Running on localhost:6000");

app.Run();