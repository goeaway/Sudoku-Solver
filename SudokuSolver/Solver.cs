using System;
using System.Collections.Generic;
using System.Linq;

namespace SudokuSolver
{
    public static class Solver
    {
        public static Sudoku Solve(Sudoku sudoku)
        {
            if (sudoku == null)
            {
                throw new ArgumentNullException(nameof(sudoku));
            }

            if (sudoku.Cells.All(c => c.Value == 0) || Checker.Check(sudoku))
            {
                return sudoku;
            }

            InnerSolve(sudoku);

            return sudoku;
        }

        private static bool InnerSolve(Sudoku sudoku)
        {
            var empty = sudoku.GetEmptyCells();

            if (!empty.Any())
            {
                return true;
            }

            var workingCell = empty.First();

            foreach (var n in Enumerable.Range(1, 9))
            {
                if (sudoku.ValuePossible(workingCell, n))
                { 
                    workingCell.Value = n;

                    if (InnerSolve(sudoku))
                    {
                        return true;
                    }
                    // backtrack
                    workingCell.Value =  0;
                }
            }

            return false;
        }
    }
}
