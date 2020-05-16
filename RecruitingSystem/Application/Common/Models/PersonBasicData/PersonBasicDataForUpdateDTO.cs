using Application.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Models.PersonBasicData
{
    public class PersonBasicDataForUpdateDTO : IMapFrom<Domain.Entities.PersonBasicData>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public int PhoneNumber { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<PersonBasicDataForUpdateDTO, Domain.Entities.PersonBasicData>();
        }
    }
}
