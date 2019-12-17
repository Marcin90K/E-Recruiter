using RecruitingSystem.Infrastructure.Models.Candidate;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitingSystem.Infrastructure.Models.Education
{
    public class EducationForCreationDTO
    {
        public string SchoolName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CourseName { get; set; }
        public Guid CandidateId { get; set; }

    }
}
