using System;

namespace Application.Common.Models.Education
{
    public class EducationDTO
    {
        public Guid Id { get; set; }
        public string SchoolName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CourseName { get; set; }
        public Guid CandidateId { get; set; }
    }
}
