using Application.Common.Mapping;
using Domain.Entities;
using System;

namespace Application.JobOffers.Commands.CreateJobOffer
{
    public class JobOfferCreatedVm : IMapFrom<JobOffer>
    {
        public Guid Id { get; set; }
        public Guid JobPositionId { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public DateTime DateOfAdding { get; set; }
        public DateTime DateOfExpiration { get; set; }
        public Guid OwnerId { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<JobOffer, JobOfferCreatedVm>()
                 .ForMember(dest => dest.OwnerId, opt => opt.MapFrom(src => src.EmployeeId));
        }
    }
}
