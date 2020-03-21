using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SudokuSolver.API.Models;

namespace SudokuSolver.API.Commands
{
    public class SolveSudokuImageRequest : IRequest<SolveSudokuResponseModel>
    {
        public byte[] Data { get; }

        public SolveSudokuImageRequest(byte[] data)
        {
            Data = data;
        }
    }
}
