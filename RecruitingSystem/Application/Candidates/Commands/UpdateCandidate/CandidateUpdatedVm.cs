using Application.Common.Mapping;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Candidates.Commands.UpdateCandidate
{
    public class CandidateUpdatedVm : IMapFrom<Candidate>
    {
        public Guid CandidateBasicDataId { get; set; }
        public ICollection<Guid> Educations { get; set; }
        public ICollection<Guid> Experiences { get; set; }
        public decimal ExpectedSalary { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<Domain.Entities.Candidate, CandidateUpdatedVm>()
                .ForMember(dest => dest.CandidateBasicDataId, opt => opt.MapFrom(src => src.BasicData.Id))
                .ForMember(dest => dest.Educations, opt => opt.MapFrom(src => src.Educations.Select(ed => ed.Id)))
                .ForMember(dest => dest.Experiences, opt => opt.MapFrom(src => src.Experiences.Select(ex => ex.Id)));
        }
    }
}
