using RecruitingSystem.Infrastructure.Models.Employee;
using RecruitingSystem.Infrastructure.Models.JobOffer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitingSystem.Infrastructure.Models.Recruiter
{
    public class RecruiterForCreationDTO
    {
        public ICollection<JobOfferForCreationDTO> OwnedJobOffers { get; set; }
        public EmployeeForCreationDTO Employee { get; set; }
        public Guid ManagerId { get; set; }
    }
}
