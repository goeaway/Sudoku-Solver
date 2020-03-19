﻿using System;
using BenchmarkDotNet.Running;

namespace SudokuSolver.Benchmarks
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<SolveBenchmarks>();
        }
    }
}
