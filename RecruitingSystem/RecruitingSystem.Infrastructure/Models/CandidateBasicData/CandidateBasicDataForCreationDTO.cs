using RecruitingSystem.Infrastructure.Models.Address;
using RecruitingSystem.Infrastructure.Models.Candidate;
using RecruitingSystem.Infrastructure.Models.PersonBasicData;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitingSystem.Infrastructure.Models.CandidateBasicData
{
    public class CandidateBasicDataForCreationDTO
    {
        public PersonBasicDataForCreationDTO PersonBasicData { get; set; }
        public int PhoneNumber { get; set; }
        public AddressForCreationDTO Address { get; set; }
        public Guid CandidateId { get; set; }
    }
}
