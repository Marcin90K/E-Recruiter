using System;
using System.Collections.Generic;
using System.Text;

namespace RecruitingSystem.Infrastructure.Models.CandidateJobOffer
{
    class CandidateJobOfferForManipulationDTO
    {
        public Guid CandidateId { get; set; }
        public Guid JobOfferId { get; set; }
    }
}
