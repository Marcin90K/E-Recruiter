using Application.Common.Models.Address;
using Application.Common.Models.PersonBasicData;

namespace Application.Common.Models.CandidateBasicData
{
    public class CandidateBasicDataForManipulationDTO
    {
        public PersonBasicDataForManipulationDTO PersonBasicData { get; set; }
        public int PhoneNumber { get; set; }
        public AddressForManipulationDTO Address { get; set; }
    }
}
