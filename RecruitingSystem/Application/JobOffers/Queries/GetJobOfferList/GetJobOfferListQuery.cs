using Application.Common.Utilities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.JobOffers.Queries.GetJobOfferList
{
    public class GetJobOfferListQuery : IRequest<JobOfferListVm>
    {
        public ResourceParameters ResourceParameters { get; set; }
    }
}
