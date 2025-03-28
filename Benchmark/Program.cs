using BenchmarkDotNet.Running;

namespace Benchmark;

class Program
{
    static void Main(string[] args)
    {
        var config = new AllowNonOptimized();
        BenchmarkRunner.Run<BenchmarkHarness>(config);
        Console.ReadKey();
    }
}