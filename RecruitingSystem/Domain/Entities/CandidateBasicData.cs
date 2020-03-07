using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class CandidateBasicData : Entity
    {
        [Required]
        public virtual PersonBasicData PersonBasicData { get; set; }

        public int PhoneNumber { get; set; }

        [Required]
        public virtual Address Address { get; set; }

        public Guid CandidateId { get; set; }

        [ForeignKey("CandidateId")]
        public virtual Candidate Candidate { get; set; }
    }
}
