using RecruitingSystem.Infrastructure.Models.JobPosition;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitingSystem.Infrastructure.Models.JobOffer
{
    public class JobOfferForCreationDTO
    {
        public int ReferenceNumber { get; set; }

        public JobPositionForCreationDTO JobPosition { get; set; }

        public string Description { get; set; }

        public DateTime DateOfAdding { get; set; }

        public DateTime DateOfExpiration { get; set; }

        public string Requirements { get; set; }

        public Guid EmployeeId { get; set; }

        public ICollection<Guid> CandidateIds { get; set; } = new List<Guid>();
    }
}
