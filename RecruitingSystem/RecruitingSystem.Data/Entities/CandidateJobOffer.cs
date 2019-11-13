using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitingSystem.Data.Entities
{
    public class CandidateJobOffer
    {
        public Guid CandidateId { get; set; }

        public Candidate Candidate { get; set; }

        public Guid JobOfferId { get; set; }

        public JobOffer JobOffer { get; set; }
    }
}
