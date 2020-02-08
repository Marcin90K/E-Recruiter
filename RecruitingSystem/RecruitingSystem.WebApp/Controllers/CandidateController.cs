using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecruitingSystem.Infrastructure.Service.Abstract;


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
