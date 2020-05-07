using Application.Candidates.Commands.CreateCandidate;
using Application.Candidates.Commands.DeleteCandidate;
using Application.Candidates.Commands.UpdateCandidate;
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

        [HttpGet("{id}", Name = "GetCandidate")]
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

        [HttpPost]
        public async Task<IActionResult> CreateCandidate([FromBody]CreateCandidateCommand command)
        {
            var candidateCreated = await _mediator.Send(command);
            return CreatedAtRoute("GetCandidate", new { candidateCreated.Id }, candidateCreated);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCandidate([FromBody]UpdateCandidateCommand command, Guid id)
        {
            command.Id = id;
            var candidateUpdated = await _mediator.Send(command);
            return Ok(candidateUpdated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidate(Guid id)
        {
            await _mediator.Send(new DeleteCandidateCommand() { Id = id });
            return NoContent();
        }
    }
}
