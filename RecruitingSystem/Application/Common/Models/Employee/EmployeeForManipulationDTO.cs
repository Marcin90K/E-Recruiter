using Application.Common.Models.PersonBasicData;

namespace Application.Common.Models.Employee
{
    public class EmployeeForManipulationDTO
    {
        public string EmployeeCompanyId { get; set; }
        public PersonBasicDataForManipulationDTO PersonBasicData { get; set; }
    }
}
