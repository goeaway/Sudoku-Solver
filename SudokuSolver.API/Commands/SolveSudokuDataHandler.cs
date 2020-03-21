using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SudokuSolver.API.Models;

namespace SudokuSolver.API.Commands
{
    public class SolveSudokuDataHandler : IRequestHandler<SolveSudokuDataRequest, SolveSudokuResponseModel>
    {
        public Task<SolveSudokuResponseModel> Handle(SolveSudokuDataRequest dataRequest, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var result = Solver.Solve(new Sudoku(dataRequest.Board));
                return new SolveSudokuResponseModel
                {
                    Solved = Checker.Check(result),
                    Board = result.ToMultiArray()
                };
            });
        }
    }
}
