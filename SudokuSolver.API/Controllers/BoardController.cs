using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SudokuSolver.API.Queries;

namespace SudokuSolver.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoardController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BoardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("new")]
        public Task<int[,]> New(Difficulty difficulty, int? seed = null)
        {
            return _mediator.Send(new GetSudokuRequest(difficulty, seed));
        }
    }
}