using RecruitingSystem.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitingSystem.Data.Entities
{
    public class Manager : Employee
    {
        public Department Department { get; set; }

        public ICollection<Recruiter> Recruiters { get; set; }
    }
}
