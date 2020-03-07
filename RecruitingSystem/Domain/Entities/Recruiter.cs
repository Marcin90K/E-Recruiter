using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class Recruiter : Entity
    {
        public virtual ICollection<JobOffer> OwnedJobOffers { get; set; }

        [ForeignKey(nameof(Employee))]
        public Guid EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        //public Guid ManagerId { get; set; }

        //[ForeignKey("ManagerId")]
        public virtual Manager Manager { get; set; }
    }
}
