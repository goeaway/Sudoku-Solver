using System;
using System.Threading;
using CommandLine;

namespace SudokuSolver.Visualiser.CLI
{
    class Program
    {
        static void Main(string[] args) => Parser.Default.ParseArguments<Options>(args)
            .WithParsed(o =>
            {
                var sudoku = Generator.Generate(o.Difficulty, o.Seed);
                var solved = SolvingEngine.Solve(sudoku, () =>
                {
                    Console.Clear();
                    Console.WriteLine(sudoku);
                    Thread.Sleep((int)o.Timeout);
                });

                var isSolved = Checker.Check(sudoku);

                Console.Clear();
                Console.WriteLine("###### SOLVED ######");
                Console.Write(sudoku);
                Console.WriteLine("###### SOLVED ######");
            });
    }
}
