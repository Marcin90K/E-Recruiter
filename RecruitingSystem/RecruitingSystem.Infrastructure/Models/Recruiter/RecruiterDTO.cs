using RecruitingSystem.Infrastructure.Models.Employee;
using RecruitingSystem.Infrastructure.Models.JobOffer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitingSystem.Infrastructure.Models.Recruiter
{
    public class RecruiterDTO
    {
        public Guid Id { get; set; }
        public ICollection<JobOfferDTO> OwnedJobOffers { get; set; }
        public EmployeeDTO Employee { get; set; }
        public Guid ManagerId { get; set; }
    }
}
