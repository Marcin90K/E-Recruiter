using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class CandidateJobOffer
    {
        public Guid CandidateId { get; set; }

        //public virtual Candidate Candidate { get; set; }

        public Candidate Candidate { get; set; }

        public Guid JobOfferId { get; set; }

        //public virtual JobOffer JobOffer { get; set; }
        public JobOffer JobOffer { get; set; }
    }
}
