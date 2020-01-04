using RecruitingSystem.Infrastructure.Models.Candidate;
using RecruitingSystem.Infrastructure.Models.JobOffer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitingSystem.Infrastructure.Models.CandidateJobOffer
{
    public class CandidateJobOfferDTO
    {
        public Guid Id { get; set; }
        public CandidateDTO Candidate { get; set; }
        public JobOfferDTO JobOffer { get; set; }
    }
}
