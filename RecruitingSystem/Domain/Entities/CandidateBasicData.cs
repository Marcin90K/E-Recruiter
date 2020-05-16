using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class CandidateBasicData : Entity
    {
        public PersonBasicData PersonBasicData { get; set; }

        public Address Address { get; set; }

        public Guid CandidateId { get; set; }

        public Candidate Candidate { get; set; }
    }
}
