using RecruitingSystem.Infrastructure.Models.Address;
using RecruitingSystem.Infrastructure.Models.Candidate;
using RecruitingSystem.Infrastructure.Models.PersonBasicData;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitingSystem.Infrastructure.Models.CandidateBasicData
{
    public class CandidateBasicDataForManipulationDTO
    {
        public PersonBasicDataForManipulationDTO PersonBasicData { get; set; }
        public int PhoneNumber { get; set; }
        public AddressForManipulationDTO Address { get; set; }
    }
}
