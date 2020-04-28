using Application.Common.Mapping;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.JobOffers.Commands.UpdateJobOffer
{
    public class JobOfferUpdatedVm : IMapFrom<JobOffer>
    {
        public Guid JobPositionId { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public DateTime DateOfExpiration { get; set; }
        public Guid OwnerId { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<JobOffer, JobOfferUpdatedVm>()
                .ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => src.EmployeeId));
        }
    }
}
