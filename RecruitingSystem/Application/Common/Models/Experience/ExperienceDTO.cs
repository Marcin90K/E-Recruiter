using System;

namespace Application.Common.Models.Experience
{
    public class ExperienceDTO
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string JobTitle { get; set; }
        public string Duties { get; set; }
        public Guid CandidateId { get; set; }
    }
}
