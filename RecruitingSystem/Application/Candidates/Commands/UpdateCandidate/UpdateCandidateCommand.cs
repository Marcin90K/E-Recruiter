using Application.Common.Mapping;
using Application.Common.Models.CandidateBasicData;
using Application.Common.Models.Education;
using Application.Common.Models.Experience;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Candidates.Commands.UpdateCandidate
{
    public class UpdateCandidateCommand : IRequest<CandidateUpdatedVm>, IMapFrom<Candidate>
    {
        public Guid EntityId { get; set; }
        public CandidateBasicDataForUpdateDTO CandidateBasicData { get; set; }
        //public CandidateBasicData CandidateBasicData { get; set; }
        public ICollection<EducationForUpdateDTO> Educations { get; set; }
        //public ICollection<Education> Educations { get; set; }
        public ICollection<ExperienceForUpdateDTO> Experiences { get; set; }
        // public ICollection<Experience> Experiences { get; set; }
        public decimal ExpectedSalary { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<UpdateCandidateCommand, Candidate>()
                .ForMember(dest => dest.BasicData, opt => opt.MapFrom(src => src.CandidateBasicData));
        }
    }
}
