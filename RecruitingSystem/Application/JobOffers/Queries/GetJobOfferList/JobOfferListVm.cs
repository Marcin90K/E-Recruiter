using Application.Common.Models.JobOffer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.JobOffers.Queries.GetJobOfferList
{
    public class JobOfferListVm
    {
        public IList<JobOfferDTO> JobOffers { get; set; }
        public int Count { get; set; }
    }
}
