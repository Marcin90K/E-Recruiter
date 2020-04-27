using Application.Common.Utilities;
using Application.JobOffers.Queries.GetJobOfferDetail;
using Application.JobOffers.Queries.GetJobOfferList;
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

        [HttpGet("joboffers/{id}")]
        public async Task<IActionResult> GetJobOffer(Guid id)
        {
            var jobOffer = await _mediator.Send(new GetJobOfferDetailQuery { Id = id });
            return Ok(jobOffer);
        }

        [HttpGet("joboffers")]
        public async Task<IActionResult> GetJobOffers([FromQuery]ResourceParameters resourceParameters)
        {
            var query = new GetJobOfferListQuery { ResourceParameters = resourceParameters };
            var jobOffers = await _mediator.Send(query);
            return Ok(jobOffers);
        }
    }
}
