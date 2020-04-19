using Application.Common.Mapping;
using System;

namespace Application.Common.Models.PersonBasicData
{
    public class PersonBasicDataDTO : IMapFrom<Domain.Entities.PersonBasicData>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<Domain.Entities.PersonBasicData, PersonBasicDataDTO>();
        }
    }
}
