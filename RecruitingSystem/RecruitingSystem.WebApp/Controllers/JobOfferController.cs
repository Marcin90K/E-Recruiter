using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecruitingSystem.Infrastructure.Models.JobOffer;
using RecruitingSystem.Infrastructure.Service.Abstract;
using RecruitingSystem.Infrastructure.Utils;

namespace RecruitingSystem.API.Controllers
{
    [Route("api/")]
    public class JobOfferController : ControllerBase
    {
        private IJobOfferService _jobOfferService;

        public JobOfferController(IJobOfferService jobOfferService)
        {
            _jobOfferService = jobOfferService;
        }

        [HttpGet("joboffers")]
        public IActionResult GetJobOffers([FromQuery]ResourceParameters resourceParameters)
        {
            var jobOffers = _jobOfferService.GetJobOffers(resourceParameters);
            return Ok(jobOffers);
        }

        [HttpGet("joboffers/{id}", Name = "GetJobOffer")]
        public IActionResult GetJobOffer(Guid id)
        {
            var jobOffer = _jobOfferService.GetJobOffer(id);

            if (jobOffer == null)
            {
                return NotFound();
            }

            return Ok(jobOffer);
        }

        [HttpPost("joboffers")]
        public IActionResult CreateJobOffer([FromBody]JobOfferForManipulationDTO jobOffer)
        {
            if (jobOffer == null)
            {
                return BadRequest();
            }

            var jobOfferCreated = _jobOfferService.AddJobOffer(jobOffer);

            return CreatedAtRoute("GetJobOffer", new { jobOfferCreated.Id }, jobOfferCreated);
        }

        [HttpPut("joboffers/{id}")]
        public IActionResult UpdateJobOffer([FromBody]JobOfferForManipulationDTO jobOffer, Guid id)
        {
            if (jobOffer == null)
            {
                return BadRequest();
            }

            var jobOfferUpdated = _jobOfferService.UpdateJobOffer(jobOffer, id);

            return Ok(jobOfferUpdated);
        }

        [HttpDelete("joboffers/{id}")]
        public IActionResult DeleteJobOffer(Guid id)
        {
            bool jobOfferExists = _jobOfferService.CheckIfJobOfferExists(id);
            if (!jobOfferExists)
            {
                return NotFound();
            }

            _jobOfferService.DeleteJobOffer(id);

            return NoContent();
        }
    }
}
