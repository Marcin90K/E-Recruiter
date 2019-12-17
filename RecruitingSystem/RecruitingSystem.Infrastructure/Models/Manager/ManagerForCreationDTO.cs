using RecruitingSystem.Data.Enums;
using RecruitingSystem.Infrastructure.Models.Employee;
using RecruitingSystem.Infrastructure.Models.Recruiter;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitingSystem.Infrastructure.Models.Manager
{
    public class ManagerForCreationDTO
    {
        public EmployeeForCreationDTO Employee { get; set; }

        public Department Department { get; set; }

        public ICollection<RecruiterForCreationDTO> Recruiters { get; set; }
    }
}
