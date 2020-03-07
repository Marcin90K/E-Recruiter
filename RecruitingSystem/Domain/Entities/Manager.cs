using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Entities
{
    public class Manager : Entity
    {
        [ForeignKey(nameof(Employee))]
        public Guid EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        public Department Department { get; set; }

        public virtual ICollection<Recruiter> Recruiters { get; set; }
    }
}
