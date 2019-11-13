using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RecruitingSystem.Data.Entities
{
    public class Experience : Entity
    {
        [Required]
        public string CompanyName { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public string JobTitle { get; set; }

        [Required]
        [MaxLength(200)]
        public string Duties { get; set; }

        public Guid CandidateId { get; set; }

        [ForeignKey("CandidateId")]
        public virtual Candidate Candidate { get; set; }
    }
}
