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

        public virtual JobPosition JobPosition { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public virtual ICollection<string> Requirements { get; set; } = new List<string>();

        public Guid EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Owner { get; set; }

        public virtual ICollection<CandidateJobOffer> CandidateJobOffers { get; set; } = new List<CandidateJobOffer>();
    }
}
