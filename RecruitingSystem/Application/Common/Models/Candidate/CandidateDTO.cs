using Application.Common.Mapping;
using Application.Common.Models.CandidateBasicData;
using Application.Common.Models.Education;
using Application.Common.Models.Experience;
using System;
using System.Collections.Generic;

namespace Application.Common.Models.Candidate
{
    public class CandidateDTO : IMapFrom<Domain.Entities.Candidate>
    {
        public Guid Id { get; set; }
        public CandidateBasicDataDTO CandidateBasicData { get; set; }
        public ICollection<EducationDTO> Educations { get; set; }
        public ICollection<ExperienceDTO> Experiences { get; set; }
        public decimal ExpectedSalary { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<Domain.Entities.Candidate, CandidateDTO>()
                .ForMember(dest => dest.CandidateBasicData, opt => opt.MapFrom(src => src.BasicData));
        }
    }
}
