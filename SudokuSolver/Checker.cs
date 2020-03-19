using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokuSolver
{
    public static class Checker
    {
        public static bool Check(Sudoku sudoku)
        {
            return sudoku.AllFilled() &&
                   sudoku.GetColumn(0).SummedValuesDistinctlyEqual(45) &&
                   sudoku.GetColumn(1).SummedValuesDistinctlyEqual(45) &&
                   sudoku.GetColumn(2).SummedValuesDistinctlyEqual(45) &&
                   sudoku.GetColumn(3).SummedValuesDistinctlyEqual(45) &&
                   sudoku.GetColumn(4).SummedValuesDistinctlyEqual(45) &&
                   sudoku.GetColumn(5).SummedValuesDistinctlyEqual(45) &&
                   sudoku.GetColumn(6).SummedValuesDistinctlyEqual(45) &&
                   sudoku.GetColumn(7).SummedValuesDistinctlyEqual(45) &&
                   sudoku.GetColumn(8).SummedValuesDistinctlyEqual(45) &&
                   
                   sudoku.GetRow(0).SummedValuesDistinctlyEqual(45) &&
                   sudoku.GetRow(1).SummedValuesDistinctlyEqual(45) &&
                   sudoku.GetRow(2).SummedValuesDistinctlyEqual(45) &&
                   sudoku.GetRow(3).SummedValuesDistinctlyEqual(45) &&
                   sudoku.GetRow(4).SummedValuesDistinctlyEqual(45) &&
                   sudoku.GetRow(5).SummedValuesDistinctlyEqual(45) &&
                   sudoku.GetRow(6).SummedValuesDistinctlyEqual(45) &&
                   sudoku.GetRow(7).SummedValuesDistinctlyEqual(45) &&
                   sudoku.GetRow(8).SummedValuesDistinctlyEqual(45) &&

                   sudoku.GetBox(0).SummedValuesDistinctlyEqual(45) &&
                   sudoku.GetBox(1).SummedValuesDistinctlyEqual(45) &&
                   sudoku.GetBox(2).SummedValuesDistinctlyEqual(45) &&
                   sudoku.GetBox(3).SummedValuesDistinctlyEqual(45) &&
                   sudoku.GetBox(4).SummedValuesDistinctlyEqual(45) &&
                   sudoku.GetBox(5).SummedValuesDistinctlyEqual(45) &&
                   sudoku.GetBox(6).SummedValuesDistinctlyEqual(45) &&
                   sudoku.GetBox(7).SummedValuesDistinctlyEqual(45) &&
                   sudoku.GetBox(8).SummedValuesDistinctlyEqual(45);
        }
    }
}
