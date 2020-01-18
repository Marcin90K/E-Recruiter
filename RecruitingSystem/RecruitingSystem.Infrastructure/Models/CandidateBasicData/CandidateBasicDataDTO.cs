using RecruitingSystem.Infrastructure.Models.Address;
using RecruitingSystem.Infrastructure.Models.Candidate;
using RecruitingSystem.Infrastructure.Models.PersonBasicData;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitingSystem.Infrastructure.Models.CandidateBasicData
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
