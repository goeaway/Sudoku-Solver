using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SudokuSolver
{
    public static class SolvingEngine
    {
        public static bool Solve(Sudoku sudoku, Action beforeInput = null)
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
                    beforeInput?.Invoke();

                    workingCell.Value = n;

                    if (Solve(sudoku, beforeInput))
                    {
                        return true;
                    }
                    // backtrack
                    workingCell.Value = 0;
                }
            }

            return false;
        }
    }
}
