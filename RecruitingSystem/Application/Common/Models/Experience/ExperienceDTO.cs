using Application.Common.Mapping;
using System;

namespace Application.Common.Models.Experience
{
    public class ExperienceDTO : IMapFrom<Domain.Entities.Experience>
    {
        public Guid Id { get; set; }
        public string CompanyName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string JobTitle { get; set; }
        public string Duties { get; set; }
        public Guid CandidateId { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<Domain.Entities.Experience, ExperienceDTO>();
        }
    }
}
