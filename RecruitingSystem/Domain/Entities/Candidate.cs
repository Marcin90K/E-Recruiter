using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class Candidate : Entity
    {
        public virtual CandidateBasicData BasicData { get; set; }

        public virtual ICollection<CandidateJobOffer> CandidateJobOffers { get; set; } = new List<CandidateJobOffer>();

        public virtual ICollection<Education> Educations { get; set; } = new List<Education>();

        public virtual ICollection<Experience> Experiences { get; set; } = new List<Experience>();

        public decimal ExpectedSalary { get; set; }
    }
}
