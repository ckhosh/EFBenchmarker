using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;
using EF6Context;

namespace EFBenchmark
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Benchmark.SetConnectionNames(args);

            BenchmarkRunner.Run<Benchmark>();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }
    }
}
