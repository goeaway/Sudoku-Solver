using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SudokuSolver.API.Commands;
using SudokuSolver.API.Models;

namespace SudokuSolver.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SolveController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SolveController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("data")]
        public Task<SolveSudokuResponseModel> SolveData(int[,] array)
            => _mediator.Send(new SolveSudokuDataRequest(array));

        [HttpPost("image")]
        public Task<SolveSudokuResponseModel> SolveImage(byte[] data)
            => _mediator.Send(new SolveSudokuImageRequest(data));
    }
}
