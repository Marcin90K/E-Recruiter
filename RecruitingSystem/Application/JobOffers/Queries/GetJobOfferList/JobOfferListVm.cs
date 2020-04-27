using Application.Common.Mapping;
using Application.Common.Models.JobOffer;
using Application.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.JobOffers.Queries.GetJobOfferList
{
    public class JobOfferListVm
    {
        public IList<JobOfferDTO> JobOffers { get; set; }
        public Pagination Pagination { get; set; }
    }
}
