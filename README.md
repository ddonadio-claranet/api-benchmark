# api-benchmark

This project was made to test the performance of different APIs. The APIs tested were:
- REST API without protocol buffer
- GRPC

I plan to add more APIs in the future, such as:
- REST API with protocol buffer
- REST API with gzip compression

## How to run
In three different terminals, run the following commands:
```bash
dotnet run --project RestApi -c Release
```
```bash
dotnet run --project gRpcApi -c Release
```
```bash
dotnet run --project Benchmark -c Release
```
The last one will produce the files under `BenchmarkDotNet.Artifacts/results` folder.

## Results (updated 2025-03-28)
```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.404
  [Host]     : .NET 8.0.11 (8.0.1124.51707), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.11 (8.0.1124.51707), Arm64 RyuJIT AdvSIMD


```
| Method                         | IterationCount | Mean      | Error    | StdDev   |
|------------------------------- |--------------- |----------:|---------:|---------:|
| **RestGetSmallPayloadAsync**       | **100**            |  **11.41 ms** | **0.205 ms** | **0.192 ms** |
| RestGetLargePayloadAsync       | 100            |  95.31 ms | 1.267 ms | 1.058 ms |
| RestPostLargePayloadAsync      | 100            | 118.84 ms | 1.965 ms | 1.838 ms |
| GrpcGetSmallPayloadAsync       | 100            |  12.84 ms | 0.225 ms | 0.211 ms |
| GrpcStreamLargePayloadAsync    | 100            | 249.06 ms | 4.844 ms | 7.251 ms |
| GrpcGetLargePayloadAsListAsync | 100            | 117.86 ms | 2.184 ms | 2.145 ms |
| GrpcPostLargePayloadAsync      | 100            | 123.81 ms | 1.509 ms | 1.260 ms |
| **RestGetSmallPayloadAsync**       | **200**            |  **22.84 ms** | **0.438 ms** | **0.410 ms** |
| RestGetLargePayloadAsync       | 200            | 205.52 ms | 2.413 ms | 2.015 ms |
| RestPostLargePayloadAsync      | 200            | 298.81 ms | 3.612 ms | 3.202 ms |
| GrpcGetSmallPayloadAsync       | 200            |  27.36 ms | 0.210 ms | 0.196 ms |
| GrpcStreamLargePayloadAsync    | 200            | 534.52 ms | 9.835 ms | 9.200 ms |
| GrpcGetLargePayloadAsListAsync | 200            | 250.63 ms | 2.415 ms | 2.141 ms |
| GrpcPostLargePayloadAsync      | 200            | 260.54 ms | 4.381 ms | 3.659 ms |

