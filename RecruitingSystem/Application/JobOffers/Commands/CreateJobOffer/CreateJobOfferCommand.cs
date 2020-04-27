using Application.Common.Mapping;
using Application.Common.Models.JobOffer;
using Application.Common.Models.JobPosition;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.JobOffers.Commands.CreateJobOffer
{
    public class CreateJobOfferCommand : IRequest<JobOfferDTO>, IMapFrom<JobOffer>
    {
        public int ReferenceNumber { get; set; }
        public JobPositionForManipulationDTO JobPosition { get; set; }
        public string Description { get; set; }
        public DateTime DateOfExpiration { get; set; }
        public string Requirements { get; set; }
        public Guid OwnerId { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<CreateJobOfferCommand, JobOffer>()
                 .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.OwnerId));
        }
    }
}
