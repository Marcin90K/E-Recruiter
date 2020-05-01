using Application.Candidates.Queries.GetCandidateDetail;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/candidate")]
    public class CandidateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CandidateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCandidate(Guid id)
        {
            var candidate = await _mediator.Send(new GetCandidateDetailQuery() { Id = id });
            return Ok(candidate);
        }
    }
}
