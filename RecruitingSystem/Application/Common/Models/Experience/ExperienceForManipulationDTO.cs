using Application.Common.Mapping;
using System;

namespace Application.Common.Models.Experience
{
    public class ExperienceForManipulationDTO : IMapFrom<Domain.Entities.Experience>
    {
        public string CompanyName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string JobTitle { get; set; }
        public string Duties { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<ExperienceForManipulationDTO, Domain.Entities.Experience>();
        }
    }
}
