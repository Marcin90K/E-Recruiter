using Application.Common.Mapping;
using System;

namespace Application.Common.Models.JobPosition
{
    public class JobPositionDTO : IMapFrom<Domain.Entities.JobPosition>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<Domain.Entities.JobPosition, JobPositionDTO>();
        }
    }
}
