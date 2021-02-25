using ArrayPoolingBencmarkTests;
using BenchmarkDotNet.Running;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<ArrayPoolingBenchmarks>();
            Console.ReadKey();
        }
    }
}
