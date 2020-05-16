using Application.Common.Models.Employee;
using Application.Common.Models.JobOffer;
using System;
using System.Collections.Generic;

namespace Application.Common.Models.Recruiter
{
    public class RecruiterForManipulationDTO
    {
        public ICollection<JobOfferForManipulationDTO> OwnedJobOffers { get; set; }
        public EmployeeForManipulationDTO Employee { get; set; }
        public Guid ManagerId { get; set; }
    }
}
