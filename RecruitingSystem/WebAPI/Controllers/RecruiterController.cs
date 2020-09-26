using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Recruiters.Queries.GetRecruiterDetail;
using Application.Common.Utilities;
using Application.Recruiters.Queries.GetRecruiterList;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/recruiter")]
    public class RecruiterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RecruiterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRecruiter(Guid id)
        {
            var recruiter = await _mediator.Send(new GetRecruiterDetailQuery() { Id = id });
            return Ok(recruiter);
        }

        [HttpGet]
        public async Task<IActionResult> GetRecruiters([FromQuery] ResourceParameters resourceParameters)
        {
            var query = new GetRecruiterListQuery() { ResourceParameters = resourceParameters };
            var recruiters = await _mediator.Send(query);
            return Ok(recruiters);
        }
    }
}
