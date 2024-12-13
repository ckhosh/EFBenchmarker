// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using SQLBenchmark;


Benchmark.ConnectionNames=args;

BenchmarkRunner.Run<Benchmark>();
Console.WriteLine("Press any key to continue");
Console.ReadKey();