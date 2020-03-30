using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class Education : Entity
    {
        public string SchoolName { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string CourseName { get; set; }

        public Guid CandidateId { get; set; }

        public virtual Candidate Candidate { get; set; }
    }
}
