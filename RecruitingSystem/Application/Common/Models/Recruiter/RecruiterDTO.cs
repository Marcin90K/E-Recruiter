using Application.Common.Models.Employee;
using Application.Common.Models.JobOffer;
using System;
using System.Collections.Generic;

namespace Application.Common.Models.Recruiter
{
    public class RecruiterDTO
    {
        public Guid Id { get; set; }
        public ICollection<JobOfferDTO> OwnedJobOffers { get; set; }
        public EmployeeDTO Employee { get; set; }
        public Guid ManagerId { get; set; }
    }
}
