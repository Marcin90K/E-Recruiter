using Application.Candidates.Queries.GetCandidateDetail;
using Application.Candidates.Queries.GetCandidateList;
using Application.Common.Utilities;
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

        [HttpGet]
        public async Task<IActionResult> GetCandidates([FromQuery]ResourceParameters resourceParameters)
        {
            var query = new GetCandidateListQuery() { ResourceParameters = resourceParameters };
            var candidates = await _mediator.Send(query);
            return Ok(candidates);
        }
    }
}
