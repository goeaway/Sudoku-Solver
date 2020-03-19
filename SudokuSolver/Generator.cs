using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;

namespace SudokuSolver
{
    public static class Generator
    {
        private static int GetGivens(Difficulty difficulty)
        {
            switch (difficulty)
            {
                case Difficulty.Easy:
                    return 40;
                case Difficulty.Medium:
                    return 32;
                case Difficulty.Hard:
                    return 28;
                case Difficulty.Expert:
                    return 22;
                case Difficulty.BloodyHard:
                    return 15;
                default: 
                    throw new NotSupportedException(difficulty.ToString());
            }
        }

        private static Sudoku SetFirstRow(Sudoku sudoku, Random random)
        {
            var values = Enumerable.Range(1, 9).ToList();

            foreach (var cell in sudoku.GetRow(0))
            {
                var choiceIndex = random.Next(0, values.Count);
                var choice = values[choiceIndex];
                cell.Value = choice;
                values.RemoveAt(choiceIndex);
            }

            return sudoku;
        }

        private static Sudoku RemoveValues(Sudoku sudoku, int givens, Random random)
        {
            var givenCells = new List<Cell>();

            // when the puzzle is full create a random list of indexes of the given length
            // reset everything not in this collection to zero
            for (var i = 0; i < givens; i++)
            {
                var usableCells = sudoku.Cells.Where(c => !givenCells.Contains(c)).ToList();

                givenCells.Add(usableCells[random.Next(0, usableCells.Count)]);
            }

            for (var i = 0; i < sudoku.Cells.Count; i++)
            {
                var cell = sudoku.Cells.ElementAt(i);
                if (!givenCells.Contains(cell))
                {
                    cell.Value = 0;
                }
            }

            return sudoku;
        }

        public static Sudoku Generate(Difficulty difficulty, int? seed = null)
        {
            // allow for control if wanted via the seed
            var random = new Random(seed.HasValue ? seed.GetValueOrDefault() + (int)difficulty : Environment.TickCount);
            // get an empty one
            var empty = Sudoku.Empty;
            // randomise the top row
            var started = SetFirstRow(empty, random);
            // solve the puzzle
            var solved = Solver.Solve(started);
            // remove most of the values, leave an amount, depending on the difficulty
            return RemoveValues(solved, GetGivens(difficulty), random);
        }
    }
}
