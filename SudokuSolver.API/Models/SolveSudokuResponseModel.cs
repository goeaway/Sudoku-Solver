using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SudokuSolver.API.Models
{
    public class SolveSudokuResponseModel
    {
        public int[,] Board { get; set; }
        public bool Solved { get; set; }
    }
}
