using MediatR;
using SudokuSolver.API.Models;

namespace SudokuSolver.API.Commands
{
    public class SolveSudokuRequest : IRequest<SolveSudokuResponseModel>
    {
        public int[,] Board { get; }

        public SolveSudokuRequest(int[,] board)
        {
            Board = board;
        }
    }
}