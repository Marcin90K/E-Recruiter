using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class CandidateBasicData : Entity
    {
        //public virtual PersonBasicData PersonBasicData { get; set; }
        public PersonBasicData PersonBasicData { get; set; }

        //public virtual Address Address { get; set; }
        public Address Address { get; set; }

        public Guid CandidateId { get; set; }

        //public virtual Candidate Candidate { get; set; }
        public Candidate Candidate { get; set; }
    }
}
