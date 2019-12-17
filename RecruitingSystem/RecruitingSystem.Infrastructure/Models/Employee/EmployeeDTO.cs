using RecruitingSystem.Infrastructure.Models.PersonBasicData;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitingSystem.Infrastructure.Models.Employee
{
    public class EmployeeDTO
    {
        public Guid Id { get; set; }
        public string EmployeeCompanyId { get; set; }
        public PersonBasicDataDTO PersonBasicData { get; set; }
    }
}
