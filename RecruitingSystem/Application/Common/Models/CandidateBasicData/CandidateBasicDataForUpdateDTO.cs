using Application.Common.Mapping;
using Application.Common.Models.Address;
using Application.Common.Models.PersonBasicData;
using System;

namespace Application.Common.Models.CandidateBasicData
{
    public class CandidateBasicDataForUpdateDTO : IMapFrom<Domain.Entities.CandidateBasicData>
    {
        public Guid Id { get; set; }
        public PersonBasicDataForUpdateDTO PersonBasicData { get; set; }
        public int PhoneNumber { get; set; }
        public AddressForUpdateDTO Address { get; set; }
        public Guid CandidateId { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<CandidateBasicDataForUpdateDTO, Domain.Entities.CandidateBasicData>();
        }
    }
}
