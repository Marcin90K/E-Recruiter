using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RecruitingSystem.Data.Entities
{
    public class JobOffer : Entity
    {
        [DefaultValue(0)]
        public int ReferenceNumber { get; set; }

        public Guid JobPositionId { get; set; }

        public virtual JobPosition JobPosition { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public DateTime DateOfAdding { get; set; }

        [Required]
        public DateTime DateOfExpiration { get; set; }

        [Required]
        public string Requirements { get; set; }

        public Guid EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Recruiter Owner { get; set; }

        public virtual ICollection<CandidateJobOffer> CandidateJobOffers { get; set; } = new List<CandidateJobOffer>();
    }
}
