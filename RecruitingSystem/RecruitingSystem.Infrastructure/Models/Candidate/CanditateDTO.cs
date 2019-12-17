using RecruitingSystem.Infrastructure.Models.CandidateBasicData;
using RecruitingSystem.Infrastructure.Models.Education;
using RecruitingSystem.Infrastructure.Models.Experience;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitingSystem.Infrastructure.Models.Candidate
{
    public class CanditateDTO
    {
        public Guid Id { get; set; }
        //public Guid CandidateBasicDataId { get; set; }
        public CandidateBasicDataDTO CandidateBasicData { get; set; }
        public ICollection<EducationDTO> Educations { get; set; }
        public ICollection<ExperienceDTO> Experiences { get; set; }
        public decimal  ExpectedSalary { get; set; }
    }
}
