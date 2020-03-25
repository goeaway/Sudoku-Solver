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

            SolvingEngine.Solve(sudoku);

            return sudoku;
        }
    }
}
