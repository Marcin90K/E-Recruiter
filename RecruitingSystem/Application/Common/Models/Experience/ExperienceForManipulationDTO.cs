using System;

namespace Application.Common.Models.Experience
{
    public class ExperienceForManipulationDTO
    {
        public string CompanyName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string JobTitle { get; set; }
        public string Duties { get; set; }
    }
}
