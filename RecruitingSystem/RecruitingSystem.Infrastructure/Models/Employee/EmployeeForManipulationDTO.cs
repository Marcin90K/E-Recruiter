using RecruitingSystem.Infrastructure.Models.PersonBasicData;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitingSystem.Infrastructure.Models.Employee
{
    public class EmployeeForManipulationDTO
    {
        public string EmployeeCompanyId { get; set; }
        public PersonBasicDataForManipulationDTO PersonBasicData { get; set; }
    }
}
