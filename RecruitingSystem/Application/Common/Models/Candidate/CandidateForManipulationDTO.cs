using Application.Common.Models.CandidateBasicData;
using Application.Common.Models.Education;
using Application.Common.Models.Experience;
using System.Collections.Generic;

namespace Application.Common.Models.Candidate
{
    public class CandidateForManipulationDTO
    {
        public CandidateBasicDataForManipulationDTO CandidateBasicData { get; set; }
        public ICollection<EducationForManipulationDTO> Educations { get; set; }
        public ICollection<ExperienceForManipulationDTO> Experiences { get; set; }
        public decimal ExpectedSalary { get; set; }
    }
}
