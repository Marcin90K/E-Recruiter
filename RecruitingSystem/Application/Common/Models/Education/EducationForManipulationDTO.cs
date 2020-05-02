using Application.Common.Mapping;
using System;

namespace Application.Common.Models.Education
{
    public class EducationForManipulationDTO : IMapFrom<Domain.Entities.Education>
    {
        public string SchoolName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CourseName { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<EducationForManipulationDTO, Domain.Entities.Education>();
        }
    }
}
