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

        [HttpPost("")]
        public Task<SolveSudokuResponseModel> Solve(int[,] array)
        {
            return _mediator.Send(new SolveSudokuRequest(array));
        }
    }
}
