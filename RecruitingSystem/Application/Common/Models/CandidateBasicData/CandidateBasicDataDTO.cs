using Application.Common.Mapping;
using Application.Common.Models.Address;
using Application.Common.Models.PersonBasicData;
using System;

namespace Application.Common.Models.CandidateBasicData
{
    public class CandidateBasicDataDTO : IMapFrom<Domain.Entities.CandidateBasicData>
    {
        public Guid Id { get; set; }
        public PersonBasicDataDTO PersonBasicData { get; set; }
        public AddressDTO Address { get; set; }
        public Guid CandidateId { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<Domain.Entities.CandidateBasicData, CandidateBasicDataDTO>();
        }
    }
}
