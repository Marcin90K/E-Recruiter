using Application.Common.Models.Employee;
using Common.Enums;
using System.Collections.Generic;

namespace Application.Common.Models.Manager
{
    public class ManagerForManipulationDTO
    {
        public EmployeeForManipulationDTO Employee { get; set; }

        public Department Department { get; set; }

        public ICollection<RecruiterForManipulationDTO> Recruiters { get; set; }
    }
}
