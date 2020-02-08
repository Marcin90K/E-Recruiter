using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        [HttpGet("candidate/{id}")]
        public IActionResult GetCandidate(Guid id)
        {
            var candidate = _candidateService.GetCandidate(id);

            if (candidate == null)
            {
                return NotFound();
            }

            return Ok(candidate);
        }
    }
}
