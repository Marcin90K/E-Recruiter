using Application.Common.Utilities;
using Application.JobOffers.Commands.CreateJobOffer;
using Application.JobOffers.Commands.DeleteJobOffer;
using Application.JobOffers.Commands.UpdateJobOffer;
using Application.JobOffers.Queries.GetJobOfferDetail;
using Application.JobOffers.Queries.GetJobOfferList;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/joboffers")]
    public class JobOfferController : ControllerBase
    {
        private IMediator _mediator;

        public JobOfferController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}", Name = "GetJobOffer")]
        public async Task<IActionResult> GetJobOffer(Guid id)
        {
            var jobOffer = await _mediator.Send(new GetJobOfferDetailQuery { Id = id });
            return Ok(jobOffer);
        }

        [HttpGet]
        public async Task<IActionResult> GetJobOffers([FromQuery]ResourceParameters resourceParameters)
        {
            var query = new GetJobOfferListQuery { ResourceParameters = resourceParameters };
            var jobOffers = await _mediator.Send(query);
            return Ok(jobOffers);
        }

        [HttpPost]
        public async Task<IActionResult> CreateJobOffer([FromBody] CreateJobOfferCommand command)
        {
            var jobOfferCreated = await _mediator.Send(command);
            return CreatedAtRoute("GetJobOffer", new { jobOfferCreated.Id }, jobOfferCreated);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJobOffer([FromBody] UpdateJobOfferCommand command, Guid id)
        {
            command.Id = id;
            var jobOfferUpdated = await _mediator.Send(command);
            return Ok(jobOfferUpdated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJobOffer(Guid id)
        {
            await _mediator.Send(new DeleteJobOfferCommand() { Id = id });
            return NoContent();
        }
    }
}
