using Application.JobOffers.Queries.GetJobOfferDetail;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    public class JobOfferController : ControllerBase
    {
        private IMediator _mediator;

        public JobOfferController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("joboffer/{id}")]
        public async Task<IActionResult> GetJobOffer(Guid id)
        {
            var jobOffer = await _mediator.Send(new GetJobOfferDetailQuery { Id = id });
            return Ok(jobOffer);
        }
    }
}
