using RecruitingSystem.Infrastructure.Models.CandidateBasicData;
using RecruitingSystem.Infrastructure.Models.Education;
using RecruitingSystem.Infrastructure.Models.Experience;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitingSystem.Infrastructure.Models.Candidate
{
    public class CandidateForManipulationDTO
    {
        public CandidateBasicDataForManipulationDTO CandidateBasicData { get; set; }
        public ICollection<EducationForManipulationDTO> Educations { get; set; }
        public ICollection<ExperienceForManipulationDTO> Experiences { get; set; }
        public decimal ExpectedSalary { get; set; }
    }
}
