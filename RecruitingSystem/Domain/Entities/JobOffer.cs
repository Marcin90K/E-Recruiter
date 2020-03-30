using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class JobOffer : Entity
    {
        public Guid JobPositionId { get; set; }

        public virtual JobPosition JobPosition { get; set; }

        public string Description { get; set; }

        public DateTime DateOfAdding { get; set; }

        public DateTime DateOfExpiration { get; set; }

        public string Requirements { get; set; }

        public Guid EmployeeId { get; set; }

        public virtual Recruiter Owner { get; set; }

        public virtual ICollection<CandidateJobOffer> CandidateJobOffers { get; set; } = new List<CandidateJobOffer>();
    }
}
