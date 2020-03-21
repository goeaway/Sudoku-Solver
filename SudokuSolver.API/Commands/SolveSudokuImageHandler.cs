using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SudokuSolver.API.Models;

namespace SudokuSolver.API.Commands
{
    public class SolveSudokuImageHandler : IRequestHandler<SolveSudokuImageRequest, SolveSudokuResponseModel>
    {
        public Task<SolveSudokuResponseModel> Handle(SolveSudokuImageRequest request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                // pass image data to the ML module 
                // receive the data from there

                var sudoku = new Sudoku(null);
                var solved = Solver.Solve(sudoku);

                return new SolveSudokuResponseModel
                {
                    Board = solved.ToMultiArray(),
                    Solved = Checker.Check(solved)
                };
            });
        }
    }
}
