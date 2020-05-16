using Application.Common.Mapping;

namespace Application.Common.Models.JobPosition
{
    public class JobPositionForManipulationDTO : IMapFrom<Domain.Entities.JobPosition>
    {
        public string Name { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<JobPositionForManipulationDTO, Domain.Entities.JobPosition>();
        }
    }
}
