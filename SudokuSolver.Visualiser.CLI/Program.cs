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
                Console.CursorVisible = false;
                var sudoku = Generator.Generate(o.Difficulty, o.Seed);
                var firstRun = true;

                var solved = SolvingEngine.Solve(sudoku, () =>
                {
                    // overwrite the last, 
                    // doing this way avoids flicker
                    Console.SetCursorPosition(0, firstRun ? Console.CursorTop : Console.CursorTop - 11);
                    Console.Write(sudoku);
                    Thread.Sleep((int)o.Timeout);

                    firstRun = false;
                });

                Console.SetCursorPosition(0, firstRun ? Console.CursorTop : Console.CursorTop - 11);
                Console.WriteLine("###### SOLVED ###### ");
                Console.Write(sudoku);
                Console.WriteLine("###### SOLVED ###### ");
            });
    }
}
