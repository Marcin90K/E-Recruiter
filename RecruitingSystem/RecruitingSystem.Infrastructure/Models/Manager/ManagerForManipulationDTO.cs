using RecruitingSystem.Data.Enums;
using RecruitingSystem.Infrastructure.Models.Employee;
using RecruitingSystem.Infrastructure.Models.Recruiter;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitingSystem.Infrastructure.Models.Manager
{
    public class ManagerForManipulationDTO
    {
        public EmployeeForManipulationDTO Employee { get; set; }

        public Department Department { get; set; }

        public ICollection<RecruiterForManipulationDTO> Recruiters { get; set; }
    }
}
