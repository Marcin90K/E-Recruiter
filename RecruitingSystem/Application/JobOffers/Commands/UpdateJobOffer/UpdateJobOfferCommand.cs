using Application.Common.Mapping;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.JobOffers.Commands.UpdateJobOffer
{
    public class UpdateJobOfferCommand : IRequest<JobOfferUpdatedVm>, IMapFrom<JobOffer>
    {
        public Guid Id { get; set; }
        public Guid JobPositionId { get; set; }
        public string Description { get; set; }
        public DateTime DateOfExpiration { get; set; }
        public string Requirements { get; set; }
        public Guid OwnerId { get; set; }
        public Guid CandidateId { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<UpdateJobOfferCommand, JobOffer>()
                 .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.OwnerId));
        }
    }
}
