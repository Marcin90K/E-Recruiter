using Application.Common.Mapping;
using Application.Common.Models.Candidate;
using Application.Common.Models.JobOffer;
using System;

namespace Application.Common.Models.CandidateJobOffer
{
    public class CandidateJobOfferDTO : IMapFrom<Domain.Entities.CandidateJobOffer>
    {
        public Guid Id { get; set; }
        public CandidateDTO Candidate { get; set; }
        public JobOfferDTO JobOffer { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<Domain.Entities.CandidateJobOffer, CandidateJobOfferDTO>();
        }
    }
}
