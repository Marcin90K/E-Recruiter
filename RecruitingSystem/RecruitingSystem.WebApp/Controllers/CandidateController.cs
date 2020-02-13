using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecruitingSystem.Infrastructure.Models.Candidate;
using RecruitingSystem.Infrastructure.Service.Abstract;
using RecruitingSystem.Infrastructure.Utils;

namespace RecruitingSystem.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private ICandidateService _candidateService;

        public CandidateController(ICandidateService candidateService)
        {
            _candidateService = candidateService;
        }

        [HttpGet("candidates")]
        public IActionResult GetCandidates([FromQuery]ResourceParameters resourceParameters)
        {
            var candidates = _candidateService.GetCandidates(resourceParameters);
            return Ok(candidates);
        }

        [HttpGet("candidates/{id}", Name = "GetCandidate")]
        public IActionResult GetCandidate(Guid id)
        {
            var candidate = _candidateService.GetCandidate(id);

            if (candidate == null)
            {
                return NotFound();
            }

            return Ok(candidate);
        }

        [HttpPost("candidates")]
        public IActionResult CreateCandidate([FromBody]CandidateForManipulationDTO candidate)
        {
            if (candidate == null)
            {
                return BadRequest();
            }

            var candidateCreated = _candidateService.AddCandidate(candidate);

            return CreatedAtRoute("GetCandidate", new { candidateCreated.Id }, candidateCreated);
        }

        [HttpDelete("candidates/{id}")]
        public IActionResult DeleteCandidate(Guid id)
        {
            var candidateExists = _candidateService.CheckIfCandidateExists(id);
            if (!candidateExists)
            {
                return NotFound();
            }

            _candidateService.DeleteCandidate(id);

            return NoContent();
        }


    }
}
