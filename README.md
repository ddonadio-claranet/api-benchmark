# api-benchmark

This project was made to test the performance of different APIs. The APIs tested were:
- REST API without protocol buffer
- GRPC
- REST API with gzip compression

I plan to add more APIs in the future, such as:
- REST API with protocol buffer



The data used is  the NASA meteorite landings data set of 1000 data points found at https://data.nasa.gov/resource/y77d-th95.json.

## How to run
In four different terminals, run the following commands:
```bash
dotnet run --project RestApi -c Release
```
```bash
dotnet run --project RestApiWithGzip -c Release
```
```bash
dotnet run --project gRpcApi -c Release
```
```bash
dotnet run --project Benchmark -c Release
```
The last one will produce the files under `BenchmarkDotNet.Artifacts/results` folder.

