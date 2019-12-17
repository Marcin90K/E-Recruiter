using RecruitingSystem.Infrastructure.Models.CandidateBasicData;
using RecruitingSystem.Infrastructure.Models.Education;
using RecruitingSystem.Infrastructure.Models.Experience;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitingSystem.Infrastructure.Models.Candidate
{
    public class CandidateForCreationDTO
    {
        public CandidateBasicDataForCreationDTO CandidateBasicData { get; set; }
        public ICollection<EducationForCreationDTO> Educations { get; set; }
        public ICollection<ExperienceForCreationDTO> Experiences { get; set; }
        public decimal ExpectedSalary { get; set; }
    }
}
