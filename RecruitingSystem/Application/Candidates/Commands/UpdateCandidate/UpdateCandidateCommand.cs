using Application.Common.Mapping;
using Application.Common.Models.CandidateBasicData;
using Application.Common.Models.CandidateJobOffer;
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
        public Guid Id { get; set; }
        public CandidateBasicDataForUpdateDTO CandidateBasicData { get; set; }
        public ICollection<EducationForUpdateDTO> Educations { get; set; }
        public ICollection<ExperienceForUpdateDTO> Experiences { get; set; }
        public decimal ExpectedSalary { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<UpdateCandidateCommand, Candidate>()
                .ForMember(dest => dest.BasicData, opt => opt.MapFrom(src => src.CandidateBasicData))
                .ForMember(dest => dest.Educations, opt => opt.Ignore())
                .ForMember(dest => dest.Experiences, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
