using System.Collections.Generic;
using System.Linq;

namespace SudokuSolver
{
    public static class Extensions
    {
        public static bool SummedValuesDistinctlyEqual(this IReadOnlyCollection<Cell> cells, int sumToMatch)
        {
            return cells
               .GroupBy(c => c.Value)
               .Select(g => g.Key)
               .Sum() == sumToMatch;
        }
    }
}