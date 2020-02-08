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

        [HttpGet("joboffer/{id}")]
        public ActionResult GetJobOffer(Guid id)
        {
            var jobOffer = _jobOfferService.GetJobOffer(id);

            if (jobOffer == null)
            {
                return NotFound();
            }

            return Ok(jobOffer);
        }
    }
}
