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

## Results (updated 2025-03-28)
```

BenchmarkDotNet v0.14.0, macOS Sonoma 14.5 (23F79) [Darwin 23.5.0]
Apple M1, 1 CPU, 8 logical and 8 physical cores
.NET SDK 8.0.404
  [Host]     : .NET 8.0.11 (8.0.1124.51707), Arm64 RyuJIT AdvSIMD
  DefaultJob : .NET 8.0.11 (8.0.1124.51707), Arm64 RyuJIT AdvSIMD


```
| Method                            | IterationCount | Mean      | Error     | StdDev    | Median    |
|---------------------------------- |--------------- |----------:|----------:|----------:|----------:|
| **RestGetSmallPayloadAsync**          | **100**            |  **11.25 ms** |  **0.225 ms** |  **0.210 ms** |  **11.31 ms** |
| RestGetLargePayloadAsync          | 100            |  93.00 ms |  1.363 ms |  1.138 ms |  92.82 ms |
| RestPostLargePayloadAsync         | 100            | 139.09 ms |  9.471 ms | 27.776 ms | 132.20 ms |
| RestWithGzipGetSmallPayloadAsync  | 100            |  11.38 ms |  0.158 ms |  0.148 ms |  11.38 ms |
| RestWithGzipGetLargePayloadAsync  | 100            | 161.80 ms |  2.827 ms |  2.361 ms | 161.33 ms |
| RestWithGzipPostLargePayloadAsync | 100            | 184.95 ms |  3.693 ms |  4.671 ms | 185.43 ms |
| GrpcGetSmallPayloadAsync          | 100            |  13.84 ms |  0.113 ms |  0.100 ms |  13.82 ms |
| GrpcStreamLargePayloadAsync       | 100            | 297.67 ms |  5.241 ms |  4.092 ms | 298.75 ms |
| GrpcGetLargePayloadAsListAsync    | 100            | 165.97 ms |  4.653 ms | 12.895 ms | 163.18 ms |
| GrpcPostLargePayloadAsync         | 100            | 141.68 ms |  2.764 ms |  4.542 ms | 141.56 ms |
| **RestGetSmallPayloadAsync**          | **200**            |  **22.94 ms** |  **0.488 ms** |  **1.424 ms** |  **23.42 ms** |
| RestGetLargePayloadAsync          | 200            | 215.45 ms |  1.758 ms |  1.373 ms | 215.50 ms |
| RestPostLargePayloadAsync         | 200            | 258.10 ms |  4.699 ms |  4.395 ms | 257.47 ms |
| RestWithGzipGetSmallPayloadAsync  | 200            |  23.58 ms |  0.463 ms |  0.533 ms |  23.67 ms |
