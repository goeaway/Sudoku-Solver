using MediatR;

namespace SudokuSolver.API.Queries
{
    public class GetSudokuRequest : IRequest<int[,]>
    {
        public Difficulty Difficulty { get; }
        public int? Seed { get; }

        public GetSudokuRequest(Difficulty difficulty, int? seed)
        {
            Difficulty = difficulty;
            Seed = seed;
        }

    }
}