using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RecruitingSystem.Data.Entities
{
    public class CandidateJobOffer
    {
        public Guid CandidateId { get; set; }
        [ForeignKey("CandidateId")]
        public virtual Candidate Candidate { get; set; }

        public Guid JobOfferId { get; set; }
        [ForeignKey("JobOfferId")]
        public virtual JobOffer JobOffer { get; set; }
    }
}
