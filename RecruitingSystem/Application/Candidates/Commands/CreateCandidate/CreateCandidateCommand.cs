using Application.Common.Mapping;
using Application.Common.Models.CandidateBasicData;
using Application.Common.Models.Education;
using Application.Common.Models.Experience;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace Application.Candidates.Commands.CreateCandidate
{
    public class CreateCandidateCommand : IRequest<CandidateCreatedVm>, IMapFrom<Candidate>
    {
        public CandidateBasicDataForManipulationDTO CandidateBasicData { get; set; }
        public ICollection<EducationForManipulationDTO> Educations { get; set; }
        public ICollection<ExperienceForManipulationDTO> Experiences { get; set; }
        public decimal ExpectedSalary { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<CreateCandidateCommand, Candidate>()
                .ForMember(dest => dest.BasicData, opt => opt.MapFrom(src => src.CandidateBasicData));
        }
    }
}
