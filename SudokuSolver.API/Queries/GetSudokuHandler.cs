using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace SudokuSolver.API.Queries
{
    public class GetSudokuHandler : IRequestHandler<GetSudokuRequest, int[,]>
    {
        public Task<int[,]> Handle(GetSudokuRequest request, CancellationToken cancellationToken)
        {
            return Task.Run(() => Generator.Generate(request.Difficulty, request.Seed).ToMultiArray());
        }
    }
}
