using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SudokuSolver.API.Models;

namespace SudokuSolver.API.Commands
{
    public class SolveSudokuHandler : IRequestHandler<SolveSudokuRequest, SolveSudokuResponseModel>
    {
        public Task<SolveSudokuResponseModel> Handle(SolveSudokuRequest request, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var result = Solver.Solve(new Sudoku(request.Board));
                return new SolveSudokuResponseModel
                {
                    Solved = Checker.Check(result),
                    Board = result.ToMultiArray()
                };
            });
        }
    }
}
