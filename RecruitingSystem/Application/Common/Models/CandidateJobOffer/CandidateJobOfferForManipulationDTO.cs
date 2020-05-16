using Application.Common.Mapping;
using System;

namespace Application.Common.Models.CandidateJobOffer
{
    public class CandidateJobOfferForManipulationDTO : IMapFrom<Domain.Entities.CandidateJobOffer>
    {
        public Guid CandidateId { get; set; }
        public Guid JobOfferId { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<CandidateJobOfferForManipulationDTO, Domain.Entities.CandidateJobOffer>();
        }
    }
}
