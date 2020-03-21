using Application.Common.Models.Address;
using Application.Common.Models.PersonBasicData;
using System;

namespace Application.Common.Models.CandidateBasicData
{
    public class CandidateBasicDataDTO
    {
        public Guid Id { get; set; }
        public PersonBasicDataDTO PersonBasicData { get; set; }
        public int PhoneNumber { get; set; }
        public AddressDTO Address { get; set; }
        public Guid CandidateId { get; set; }
    }
}
