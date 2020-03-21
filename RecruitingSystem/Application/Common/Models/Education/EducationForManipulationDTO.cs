using System;

namespace Application.Common.Models.Education
{
    public class EducationForManipulationDTO
    {
        public string SchoolName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CourseName { get; set; }
    }
}
