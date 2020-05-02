using Application.Common.Mapping;
using Application.Common.Models.Address;
using Application.Common.Models.PersonBasicData;

namespace Application.Common.Models.CandidateBasicData
{
    public class CandidateBasicDataForManipulationDTO : IMapFrom<Domain.Entities.CandidateBasicData>
    {
        public PersonBasicDataForManipulationDTO PersonBasicData { get; set; }
        public int PhoneNumber { get; set; }
        public AddressForManipulationDTO Address { get; set; }

        public void Mapping(MappingProfile profile)
        {
            profile.CreateMap<CandidateBasicDataForManipulationDTO, Domain.Entities.CandidateBasicData>();
        }
    }
}
