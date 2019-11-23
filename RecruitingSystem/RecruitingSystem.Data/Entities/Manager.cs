using RecruitingSystem.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RecruitingSystem.Data.Entities
{
    public class Manager : Entity
    {
        [ForeignKey(nameof(Employee))]
        public Guid EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public Department Department { get; set; }

        public ICollection<Recruiter> Recruiters { get; set; }
    }
}
