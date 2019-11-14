using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RecruitingSystem.Data.Entities
{
    public class Recruiter : Employee
    {
        public virtual ICollection<JobOffer> OwnedJobOffers { get; set; }

        public Guid ManagerId { get; set; }

        [ForeignKey("ManagerId")]
        public virtual Manager Manager { get; set; }
    }
}
