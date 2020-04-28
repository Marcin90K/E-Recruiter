using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.JobOffers.Commands.DeleteJobOffer
{
    public class DeleteJobOfferCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
