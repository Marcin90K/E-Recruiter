using Application.JobOffers.Queries.GetJobOfferDetail;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebAPI.Controllers
{
    public class JobOfferController : BaseController
    {
        [HttpGet("joboffer/{id}")]
        public async Task<IActionResult> GetJobOffer(Guid id)
        {
            var jobOffer = await Mediator.Send(new GetJobOfferDetailQuery { Id = id });
            return Ok(jobOffer);
        }
    }
}
