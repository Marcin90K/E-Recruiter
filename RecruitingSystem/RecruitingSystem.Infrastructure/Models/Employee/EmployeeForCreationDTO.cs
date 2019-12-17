using RecruitingSystem.Infrastructure.Models.PersonBasicData;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitingSystem.Infrastructure.Models.Employee
{
    public class EmployeeForCreationDTO
    {
        public string EmployeeCompanyId { get; set; }
        public PersonBasicDataForCreationDTO PersonBasicData { get; set; }
    }
}
