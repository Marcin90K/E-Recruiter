using Application.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Models.Education
{
    public class EducationForUpdateDTO : IMapFrom<Domain.Entities.Education>
    {
        public string SchoolName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CourseName { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<EducationForUpdateDTO, Domain.Entities.Education>()
                .ForMember(dest => dest.Candidate, opt => opt.Ignore())
                .ForMember(dest => dest.CandidateId, opt => opt.Ignore());
        }

        //public static EducationForUpdateDTO MapFrom(Domain.Entities.Education entity)
        //{

        //}
    }
}
