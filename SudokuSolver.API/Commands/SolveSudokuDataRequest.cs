using MediatR;
using SudokuSolver.API.Models;

namespace SudokuSolver.API.Commands
{
    public class SolveSudokuDataRequest : IRequest<SolveSudokuResponseModel>
    {
        public int[,] Board { get; }

        public SolveSudokuDataRequest(int[,] board)
        {
            Board = board;
        }
    }
}