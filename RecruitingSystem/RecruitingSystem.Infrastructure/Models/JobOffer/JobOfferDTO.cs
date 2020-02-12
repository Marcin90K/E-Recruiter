using RecruitingSystem.Infrastructure.Models.JobPosition;
using RecruitingSystem.Infrastructure.Models.Recruiter;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitingSystem.Infrastructure.Models.JobOffer
{
    public class JobOfferDTO
    {
        public Guid Id { get; set; }
        public int ReferenceNumber { get; set; }

        public JobPositionDTO JobPosition { get; set; }

        public string Description { get; set; }

        public DateTime DateOfAdding { get; set; }

        public DateTime DateOfExpiration { get; set; }

        public string Requirements { get; set; }

        public RecruiterDTO Owner { get; set; }

        public ICollection<Guid> CandidateIds { get; set; } = new List<Guid>();
    }
}
