using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class Experience : Entity
    {
        public string CompanyName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string JobTitle { get; set; }

        public string Duties { get; set; }

        public Guid CandidateId { get; set; }
       
        public Candidate Candidate { get; set; }
    }
}
