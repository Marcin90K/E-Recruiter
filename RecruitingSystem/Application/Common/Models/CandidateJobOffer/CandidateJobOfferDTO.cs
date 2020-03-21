using Application.Common.Models.Candidate;
using Application.Common.Models.JobOffer;
using System;

namespace Application.Common.Models.CandidateJobOffer
{
    public class CandidateJobOfferDTO
    {
        public Guid Id { get; set; }
        public CandidateDTO Candidate { get; set; }
        public JobOfferDTO JobOffer { get; set; }
    }
}
