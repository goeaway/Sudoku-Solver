using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace SudokuSolver.Benchmarks
{
    [MemoryDiagnoser]
    public class SolveBenchmarks
    {
        private Sudoku sudoku;

        [Params(Difficulty.Easy, Difficulty.Medium, Difficulty.Hard, Difficulty.Expert, Difficulty.BloodyHard)]
        public Difficulty Difficulty;

        [GlobalSetup]
        public void Setup()
        {
            sudoku = Generator.Generate(Difficulty, 5);
        }

        [Benchmark]
        public Sudoku Solve() => Solver.Solve(sudoku);
    }
}
