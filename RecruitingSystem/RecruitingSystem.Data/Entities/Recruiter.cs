using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RecruitingSystem.Data.Entities
{
    public class Recruiter : Entity
    {
        public virtual ICollection<JobOffer> OwnedJobOffers { get; set; }

        [ForeignKey(nameof(Employee))]
        public Guid EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public virtual Manager Manager { get; set; }
    }
}
