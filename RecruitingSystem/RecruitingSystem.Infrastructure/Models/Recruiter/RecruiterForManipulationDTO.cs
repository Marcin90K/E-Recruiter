using RecruitingSystem.Infrastructure.Models.Employee;
using RecruitingSystem.Infrastructure.Models.JobOffer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitingSystem.Infrastructure.Models.Recruiter
{
    public class RecruiterForManipulationDTO
    {
        public ICollection<JobOfferForManipulationDTO> OwnedJobOffers { get; set; }
        public EmployeeForManipulationDTO Employee { get; set; }
        public Guid ManagerId { get; set; }
    }
}
