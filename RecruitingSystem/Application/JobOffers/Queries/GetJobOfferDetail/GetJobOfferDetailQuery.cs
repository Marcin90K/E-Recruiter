using Application.Common.Models.JobOffer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.JobOffers.Queries.GetJobOfferDetail
{
    public class GetJobOfferDetailQuery : IRequest<JobOfferDTO>
    {
        public Guid Id { get; set; }
    }
}
