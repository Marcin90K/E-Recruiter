using Application.Common.Models.PersonBasicData;
using System;

namespace Application.Common.Models.Employee
{
    public class EmployeeDTO
    {
        public Guid Id { get; set; }
        public string EmployeeCompanyId { get; set; }
        public PersonBasicDataDTO PersonBasicData { get; set; }
    }
}
