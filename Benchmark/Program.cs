using Benchmark;
using BenchmarkDotNet.Running;

static void Main(string[] args)
{
    BenchmarkRunner.Run<BenchmarkHarness>();
    Console.ReadKey();
}